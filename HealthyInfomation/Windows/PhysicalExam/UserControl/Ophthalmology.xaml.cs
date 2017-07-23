using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.ClientEntity.PhysicalExam.ViewModel;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System.Collections.Generic;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.FrameWork.AuthorUser;
using System.Windows;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// Ophthalmology.xaml 的交互逻辑
    /// </summary>
    public partial class Ophthalmology : WindowBase
    {
        AviationMedicineFacade aviationMedicineFacade;
        PhysicalExamMaxFacade physicalExamMaxFacade;
        AircrewEntity aircrewEntity;
        public Ophthalmology()
        {
            InitializeComponent();
        }

        public Ophthalmology(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.DataContext = this;
            this.InitData(year);
        }

        #region ViewModel

        private PhthalmologyModel ophthalmologyModel;
        public PhthalmologyModel OphthalmologyModel
        {
            get
            {
                return ophthalmologyModel;
            }
            set
            {
                ophthalmologyModel = value;
                RaisePropertyChanged("OphthalmologyModel");
            }
        }

        private List<AviationMedicineEntity> aviationMedicineList;
        public List<AviationMedicineEntity> AviationMedicineList
        {
            get
            {
                return aviationMedicineList;
            }
            set
            {
                aviationMedicineList = value;
                RaisePropertyChanged("AviationMedicineList");
            }
        }
        #endregion

        #region Command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.OphthalmologyModel.TransactionNumber > 0)
                    {
                        this.UpdatePhthalmology();
                    }
                    else
                    {
                        this.CreatePhthalmology();
                    }
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    RemovePhthalmology();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData(int year)
        {
            this.RemoveVisibility = Visibility.Collapsed;
            var response = await this.aviationMedicineFacade.GetAviationMedicineList(string.Empty, 0, 1000);
            response.AviationMedicineList.Insert(0, new AviationMedicineEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
            this.AviationMedicineList = response.AviationMedicineList;

            var opthalmology = await this.physicalExamMaxFacade.GetPhthalmology(aircrewEntity.TransactionNumber, year);
            if (opthalmology != null)
            {
                this.OphthalmologyModel = AutoMapper.Mapper.Map<PhthalmologyEntity, PhthalmologyModel>(opthalmology);
                this.RemoveVisibility = Visibility.Visible;
            }
            else
            {
                this.OphthalmologyModel = new PhthalmologyModel();
                this.OphthalmologyModel.AviationMedicineID = 0;
            }
        }

        private async void CreatePhthalmology()
        {
            if (this.OphthalmologyModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<PhthalmologyRequest>(this.OphthalmologyModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = aircrewEntity.TransactionNumber;
            await physicalExamMaxFacade.CreateOphthalmology(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdatePhthalmology()
        {
            if (this.OphthalmologyModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<PhthalmologyRequest>(this.OphthalmologyModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.TransactionNumber = OphthalmologyModel.TransactionNumber;
            await physicalExamMaxFacade.UpdateOphthalmology(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void RemovePhthalmology()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.physicalExamMaxFacade.RemoveOphthalmology(OphthalmologyModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.OphthalmologyModel = new PhthalmologyModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
