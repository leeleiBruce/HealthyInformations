using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HealthyInformation.FrameWork.ActionTrigger;
using HealthyInformation.FrameWork.Enums;
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.FrameWork.AuthorUser;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// RecuperationInformationModify.xaml 的交互逻辑
    /// </summary>
    public partial class RecuperationInformationModify : WindowBase
    {
        SanatoriumFacade sanatoriumFacade;
        AviationMedicineFacade aviationMedicineFacade;
        AircrewFacade aircrewFacade;
        RecuperationInformationFacade recuperationFacade;
        List<AircrewEntity> recuperationMemberList;
        int key = 0;
        public RecuperationInformationModify(int key)
        {
            InitializeComponent();
            this.key = key;
            sanatoriumFacade = new SanatoriumFacade(this);
            aviationMedicineFacade = new AviationMedicineFacade(this);
            aircrewFacade = new AircrewFacade(this);
            recuperationFacade = new RecuperationInformationFacade(this);
            RecuperationInformationModel = new RecuperationInformationModel();
            DataContext = this;
            InitData();
            InitTriggerAction();
            RecuperationInformationModel.PropertyChanged += RecuperationInformationModel_PropertyChanged;
        }

        #region ViewModel

        private RecuperationInformationModel recuperationInformationModel;
        public RecuperationInformationModel RecuperationInformationModel
        {
            get
            {
                return recuperationInformationModel;
            }
            set
            {
                recuperationInformationModel = value;
                RaisePropertyChanged("RecuperationInformationModel");
            }
        }

        private List<SanatoriumEntity> sanatoriumList;
        public List<SanatoriumEntity> SanatoriumList
        {
            get
            {
                return sanatoriumList;
            }
            set
            {
                sanatoriumList = value;
                RaisePropertyChanged("SanatoriumList");
            }
        }

        private ObservableCollection<RecuperationAccompanyEntity> recuperationAccompanyList;
        public ObservableCollection<RecuperationAccompanyEntity> RecuperationAccompanyList
        {
            get
            {
                return recuperationAccompanyList;
            }
            set
            {
                recuperationAccompanyList = value;
                RaisePropertyChanged("RecuperationAccompanyList");
            }
        }

        private List<RecuperationMemberEntity> RecuperationMemberList;

        #endregion

        #region Command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.SaveRecuperationInformation();
                });
            }
        }

        public ICommand PrintCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    new RecuperationPrint(key).ShowDialog();
                });
            }
        }

        public ICommand SetupCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var aircrewMemberWindow = new AircrewMember(RecuperationMemberList);
                    aircrewMemberWindow.ShowDialog();
                    recuperationMemberList = aircrewMemberWindow.Tag as List<AircrewEntity>;
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var recuperationAccompany = obj as RecuperationAccompanyEntity;
                    if (obj != null)
                    {
                        this.RecuperationAccompanyList.Remove(recuperationAccompany);
                    }
                });
            }
        }

        public ICommand NewCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.RecuperationAccompanyList == null)
                    {
                        this.RecuperationAccompanyList = new ObservableCollection<RecuperationAccompanyEntity>();
                    }

                    this.RecuperationAccompanyList.Add(new RecuperationAccompanyEntity());
                });
            }
        }

        #endregion

        #region Method

        private async void InitData()
        {
            await this.InitSanatorium();
            this.InitAviationMedicine();
            await this.InitAircrew();
            this.InitDetailData();
        }

        private void InitTriggerAction()
        {
            this.Cmb_Sanatorium.AttchEventTriggerAction(new BaseTrigger<DependencyObject, RecuperationInformation>(async (obj) =>
            {
                if (this.RecuperationInformationModel.SanatoriumID > 0)
                {
                    var sanatorium = await this.sanatoriumFacade.GetSanatoriumSingle(RecuperationInformationModel.SanatoriumID);
                    this.RecuperationInformationModel.DetailAddress = sanatorium.Address;
                    this.RecuperationInformationModel.ContactPhone = sanatorium.ContactPhone;
                    this.RecuperationInformationModel.RecommendTravelMode = sanatorium.RecommendTravelMode;
                }
            }), EventEnums.SelectionChanged.ToString());
        }

        private async void InitDetailData()
        {
            var entity = await this.recuperationFacade.GetRecuperationDetail(key);
            RecuperationInformationModel.AviationMedicineID = entity.AviationMedicineID.GetValueOrDefault(0);
            RecuperationInformationModel.SanatoriumID = entity.SanatoriumID;
            RecuperationInformationModel.AircrewEntity = RecuperationInformationModel.AircrewEntityList.FirstOrDefault(a => a.TransactionNumber == entity.LeaderAircrewID);
            RecuperationInformationModel.HospitalizationDatePlan = entity.HospitalEnterDate;
            RecuperationInformationModel.DischargeDatePlan = entity.HospitalLeaveDate;
            RecuperationAccompanyList = new ObservableCollection<RecuperationAccompanyEntity>(entity.RecuperationAccompanyEntitys);
            for (int i = 0; i <= 9; i++)
            {
                RecuperationAccompanyList.Insert(RecuperationAccompanyList.Count, new RecuperationAccompanyEntity { });
            }
            RecuperationMemberList = entity.RecuperationMembers;
            recuperationMemberList = RecuperationMemberList.Select(r =>
            {
                return new AircrewEntity
                {
                    TransactionNumber = r.AircrewID.GetValueOrDefault(0)
                };
            }).ToList();
        }

        private async void InitAviationMedicine()
        {
            var response = await aviationMedicineFacade.GetAviationMedicineList(string.Empty, 0, 2000);
            response.AviationMedicineList.Insert(0, new AviationMedicineEntity
            {
                TransactionNumber = 0,
                Name = CommonResource.Default_Select
            });
            this.RecuperationInformationModel.AviationMedicineList = response.AviationMedicineList;
        }

        private async Task InitSanatorium()
        {
            var response = await this.sanatoriumFacade.GetSanatoriumList(string.Empty, 0, 1000);
            response.SanatoriumList.Insert(0, new SanatoriumEntity
            {
                TransactionNumber = 0,
                Name = CommonResource.Default_Select
            });
            this.SanatoriumList = response.SanatoriumList;
        }

        private async Task InitAircrew()
        {
            var response = await aircrewFacade.GetAircrewList(string.Empty, DateTime.MinValue, DateTime.MaxValue, 0, 2000);
            response.AircrewList.Insert(0, new AircrewEntity
            {
                TransactionNumber = 0,
                Name = CommonResource.Default_Select
            });
            this.RecuperationInformationModel.AircrewEntityList = response.AircrewList;
            this.RecuperationInformationModel.AircrewEntity = RecuperationInformationModel.AircrewEntityList.FirstOrDefault();
        }

        private async void SaveRecuperationInformation()
        {
            if (this.recuperationMemberList == null || this.recuperationMemberList.Count == 0)
            {
                this.ShowMessage(RecuperationInformationResource.Msg_NoAircrew);
                return;
            }

            var request = new RecuperationInformationRequest();
            request.TransactionNumber = key;
            request.RecuperationMemberList = this.recuperationMemberList.Select(r =>
            {
                return new RecuperationMemberEntity
                {
                    AircrewID = r.TransactionNumber,
                    LastEditUser = CPApplication.CurrentUser.UserName
                };
            }).ToList();

            if (this.RecuperationAccompanyList.Any(r => r.HasValidationError())) return;

            request.RecuperationAccompanyList = this.RecuperationAccompanyList?
                .Where(r => !string.IsNullOrWhiteSpace(r.Name))
                .Select(r => new RecuperationAccompanyEntity
                {
                    ContactPhone = r.ContactPhone,
                    Name = r.Name,
                    LastEditUser = CPApplication.CurrentUser.UserName
                }).ToList();

            request.SanatoriumID = this.RecuperationInformationModel.SanatoriumID;
            request.AviationMedicineID = this.RecuperationInformationModel.AviationMedicineID;
            request.HospitalEnterDate = this.RecuperationInformationModel.HospitalizationDatePlan.Value;
            request.HospitalLeaveDate = this.RecuperationInformationModel.DischargeDatePlan.Value;
            request.LeaderAircrewID = this.RecuperationInformationModel.AircrewEntity.TransactionNumber; //带队领导
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            var response = await this.recuperationFacade.UpdateRecuperationInformation(request);
            if (response != null && response.IsSucess)
            {
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                this.Close();
            }
        }

        private void RecuperationInformationModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AircrewEntity")
            {
                if (RecuperationInformationModel.AircrewEntity != null)
                {
                    this.RecuperationInformationModel.LeaderContactTel = RecuperationInformationModel.AircrewEntity.TroopsTel;
                }
            }
        }

        #endregion
    }
}
