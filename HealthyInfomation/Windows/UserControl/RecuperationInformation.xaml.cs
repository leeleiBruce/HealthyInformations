using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System.Collections.Generic;
using HealthyInformation.FrameWork.ActionTrigger;
using System.Windows.Controls;
using HealthyInformation.FrameWork.Enums;
using System.Windows;
using System.Windows.Input;
using HealthyInfomation.Windows.UserControl;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.ComponentModel;
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.FrameWork.AuthorUser;
using System.Collections.ObjectModel;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// RecuperationInformation.xaml 的交互逻辑
    /// </summary>
    public partial class RecuperationInformation : WindowBase
    {
        SanatoriumFacade sanatoriumFacade;
        AviationMedicineFacade aviationMedicineFacade;
        AircrewFacade aircrewFacade;
        RecuperationInformationFacade recuperationInformationFacade;
        List<AircrewEntity> recuperationMemberList;
        public RecuperationInformation()
        {
            InitializeComponent();
            this.RecuperationInformationModel = new RecuperationInformationModel();
            this.DataContext = this;
            this.sanatoriumFacade = new SanatoriumFacade(this);
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.aircrewFacade = new AircrewFacade(this);
            this.recuperationInformationFacade = new RecuperationInformationFacade(this);
            this.InitData();
            this.InitTriggerAction();
            this.RecuperationInformationModel.PropertyChanged += RecuperationInformation_PropertyChanged;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.ShowConfirm(MainResource.Msg_ExitConfirm) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
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

        private List<AircrewEntity> aircrewEntityList;
        public List<AircrewEntity> AircrewEntityList
        {
            get
            {
                return aircrewEntityList;
            }
            set
            {
                aircrewEntityList = value;
                RaisePropertyChanged("AircrewEntityList");
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

        #endregion

        #region Command
        public ICommand SetupCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var aircrewMemberWindow = new AircrewMember(null);
                    aircrewMemberWindow.ShowDialog();
                    recuperationMemberList = aircrewMemberWindow.Tag as List<AircrewEntity>;
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.CreateRecuperationInformation();
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

        private void InitData()
        {
            this.InitSanatorium()
                .ContinueWith((a) => this.Dispatcher.Invoke(InitAviationMedicine))
                .ContinueWith((a) => this.Dispatcher.Invoke(InitAircrew));

            this.RecuperationInformationModel.AviationMedicineID = 0;
            this.RecuperationAccompanyList = new ObservableCollection<RecuperationAccompanyEntity>();
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

        private async void InitAircrew()
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

        private async void CreateRecuperationInformation()
        {
            if (this.recuperationMemberList == null || this.recuperationMemberList.Count == 0)
            {
                this.ShowMessage(RecuperationInformationResource.Msg_NoAircrew);
                return;
            }

            var request = new RecuperationInformationRequest();

            request.RecuperationMemberList = this.recuperationMemberList.Select(r =>
            {
                return new RecuperationMemberEntity
                {
                    AircrewID = r.TransactionNumber,
                    InDate = DateTime.Now,
                    InUser = CPApplication.CurrentUser.UserName,
                    LastEditDate = DateTime.Now,
                    LastEditUser = CPApplication.CurrentUser.UserName
                };
            }).ToList();

            if (this.RecuperationAccompanyList.Any(r => r.HasValidationError())) return;

            request.RecuperationAccompanyList = this.RecuperationAccompanyList
                .Where(r => !string.IsNullOrWhiteSpace(r.Name))
                .Select(r => new RecuperationAccompanyEntity
                {
                    ContactPhone = r.ContactPhone,
                    Name = r.Name,
                    InDate = DateTime.Now,
                    InUser = CPApplication.CurrentUser.UserName,
                    LastEditDate = DateTime.Now,
                    LastEditUser = CPApplication.CurrentUser.UserName
                }).ToList();

            request.SanatoriumID = this.RecuperationInformationModel.SanatoriumID;
            request.AviationMedicineID = this.RecuperationInformationModel.AviationMedicineID;
            request.HospitalEnterDate = this.RecuperationInformationModel.HospitalizationDatePlan.Value;
            request.HospitalLeaveDate = this.RecuperationInformationModel.DischargeDatePlan.Value;
            request.LeaderAircrewID = this.RecuperationInformationModel.AircrewEntity.TransactionNumber; //带队领导
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            var response = await this.recuperationInformationFacade.CreateRecuperationInformation(request);
            if (response != null && response.IsSucess)
            {
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                this.Close();
            }
        }

        private void RecuperationInformation_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
