using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.PhysicalExam.ViewModel;
using HealthyInformation.FrameWork;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork.AuthorUser;
using System.Windows;
using HealthyInfomation.Resource;
using System.ComponentModel;
using System.Collections.Generic;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// MedicalIdentification.xaml 的交互逻辑
    /// </summary>
    public partial class MedicalIdentification : WindowBase
    {
        MedicalIdentificationFacade facade;
        AviationMedicineFacade aviationMedicineFacade;
        AircrewEntity aircrewEntity;
        public MedicalIdentification()
        {
            InitializeComponent();
        }

        public MedicalIdentification(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.DataContext = this;
            this.facade = new MedicalIdentificationFacade(this);
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.InitData(year);
        }

        private MedicalIdentificationModel viewModel;
        public MedicalIdentificationModel ViewModel
        {
            get
            {
                return viewModel;
            }
            set
            {
                viewModel = value;
                RaisePropertyChanged("ViewModel");
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

        #region Command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.ViewModel.TransactionNumber > 0)
                    {
                        this.UpdateMedicalIdentification();
                    }
                    else
                    {
                        this.CreateMedicalIdentification();
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
                    this.RemoveMedicalIdentification();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData(int? year = null)
        {
            this.RemoveVisibility = Visibility.Collapsed;
            var response = await this.aviationMedicineFacade.GetAviationMedicineList(string.Empty, 0, 1000);
            response.AviationMedicineList.Insert(0, new AviationMedicineEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
            var result = await this.facade.GetMedicalIdentificationByYear(this.aircrewEntity.TransactionNumber, year.Value);
            this.ViewModel = AutoMapper.Mapper.Map<MedicalIdentificationEntity, MedicalIdentificationModel>(result);
            if (result == null)
            {
                this.ViewModel = new MedicalIdentificationModel();
            }
            else
            {
                this.RemoveVisibility = Visibility.Visible;
            }
            this.AviationMedicineList = response.AviationMedicineList;
        }


        private async void CreateMedicalIdentification()
        {
            if (this.viewModel.HasValidationError()) return;

            var request = new MedicalIdentificationRequest
            {
                AircrewID = aircrewEntity.TransactionNumber,
                Content = viewModel.Content,
                AviationMedicineID = viewModel.AviationMedicineID,
                RecordDate = viewModel.RecordDate,
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            var response = await this.facade.CreateMedicalIdentification(request);
            if (response.IsSucess)
            {
                MessageBox.Show(CommonMsgResource.Msg_SaveSuccess, "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void UpdateMedicalIdentification()
        {
            if (this.viewModel.HasValidationError()) return;

            var request = new MedicalIdentificationRequest
            {
                TransactionNumber = viewModel.TransactionNumber,
                AircrewID = aircrewEntity.TransactionNumber,
                Content = viewModel.Content,
                AviationMedicineID = viewModel.AviationMedicineID,
                RecordDate = viewModel.RecordDate,
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            await this.facade.UpdateMedicalIdentification(request);
            MessageBox.Show(CommonMsgResource.Msg_SaveSuccess, "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void RemoveMedicalIdentification()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.facade.RemoveMedicalIdentification(viewModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.ViewModel = new MedicalIdentificationModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
