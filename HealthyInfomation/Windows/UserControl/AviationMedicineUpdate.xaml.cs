using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInfomation.Resource;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// AviationMedicineUpdate.xaml 的交互逻辑
    /// </summary>
    public partial class AviationMedicineUpdate : WindowBase
    {
        AviationMedicineFacade aviationMedicineFacade;
        AviationMedicineEntity aviationMedicineEntity;
        public AviationMedicineUpdate()
        {
            InitializeComponent();

        }

        public AviationMedicineUpdate(AviationMedicineEntity aviationMedicineEntity)
            : this()
        {
            this.aviationMedicineEntity = aviationMedicineEntity;
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.AviationMedicineModel = new AviationMedicineModel();
            this.DataContext = this;
            this.InitData();
        }

        #region viewModel

        private AviationMedicineModel aviationMedicineModel;
        public AviationMedicineModel AviationMedicineModel
        {
            get { return aviationMedicineModel; }
            set
            {
                aviationMedicineModel = value;
                RaisePropertyChanged("AviationMedicineModel");
            }
        }

        private bool isEditEnabled;
        public bool IsEditEnabled
        {
            get
            {
                return isEditEnabled;
            }
            set
            {
                isEditEnabled = value;
                RaisePropertyChanged("IsEditEnabled");
            }
        }

        private bool isSaveEnabled;
        public bool IsSaveEnabled
        {
            get
            {
                return isSaveEnabled;
            }
            set
            {
                isSaveEnabled = value;
                RaisePropertyChanged("IsSaveEnabled");
            }
        }

        #endregion

        #region Command

        public ICommand UpdateCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.IsEditEnabled = false;
                    this.IsSaveEnabled = true;
                });
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.Close();
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.UpdateAviationMedicine();
                });
            }
        }

        #endregion

        #region method

        private void InitData()
        {
            this.AviationMedicineModel = AutoMapper.Mapper.Map<AviationMedicineEntity, AviationMedicineModel>(aviationMedicineEntity);
            this.IsEditEnabled = true;
            this.IsSaveEnabled = false;
        }

        private async void UpdateAviationMedicine()
        {
            if (AviationMedicineModel.HasValidationError()) return;

            var request = new AviationMedicineRequest
            {
                TransactionNumber = AviationMedicineModel.TransactionNumber,
                Name = AviationMedicineModel.Name,
                Sex = AviationMedicineModel.Sex,
                Professional = AviationMedicineModel.Professional,
                Qualifications = AviationMedicineModel.PersonQualification,
                ContactPhone = AviationMedicineModel.ContactTel,
                EmploymentDate = AviationMedicineModel.WorkDate,
                GraduationSchool = AviationMedicineModel.GraduationSchool,
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            await this.aviationMedicineFacade.UpdateAviationMedicine(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            this.DialogResult = true;
        }

        #endregion
    }
}
