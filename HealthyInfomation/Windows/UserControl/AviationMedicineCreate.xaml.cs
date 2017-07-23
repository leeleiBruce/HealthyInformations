using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInfomation.Resource;
using HealthyInformation.FrameWork.Enums;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// AviationMedicineCreate.xaml 的交互逻辑
    /// </summary>
    public partial class AviationMedicineCreate : WindowBase
    {
        AviationMedicineFacade aviationMedicineFacade;
        public AviationMedicineCreate()
        {
            InitializeComponent();
            this.AviationMedicineModel = new AviationMedicineModel();
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.DataContext = this;
            this.InitData();
        }

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

        #region Command

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
                    this.CreateAviationMedicine();
                });
            }
        }

        #endregion

        #region method

        private void InitData()
        {
            AviationMedicineModel.Sex = "1";
        }

        private void ResetData()
        {
            AviationMedicineModel.ContactTel = string.Empty;
            AviationMedicineModel.GraduationSchool = string.Empty;
            AviationMedicineModel.Name = string.Empty;
            AviationMedicineModel.Professional = string.Empty;
            AviationMedicineModel.PersonQualification = string.Empty;
            AviationMedicineModel.Sex = ((int)SexEnums.Male).ToString();
            AviationMedicineModel.WorkDate = DateTime.Now;
        }

        private async void CreateAviationMedicine()
        {
            if (this.AviationMedicineModel.HasValidationError()) return;

            if (!AviationMedicineModel.WorkDate.HasValue)
            {
                this.ShowMessage(AviationMedicineResource.Msg_WorkDateEmpty);
                return;
            }

            var request = new AviationMedicineRequest
            {
                Name = AviationMedicineModel.Name,
                Professional = AviationMedicineModel.Professional,
                ContactPhone = AviationMedicineModel.ContactTel,
                EmploymentDate = AviationMedicineModel.WorkDate,
                GraduationSchool = AviationMedicineModel.GraduationSchool,
                Qualifications = AviationMedicineModel.PersonQualification,
                Sex = AviationMedicineModel.Sex,
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            try
            {
                var response = await aviationMedicineFacade.CreateAviationMedicine(request);
                if (response.IsSucess)
                {
                    this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                    ResetData();
                }
            }
            catch (Exception ex)
            {
                this.ShowWarning(ex.Message.ToString());
            }

        }

        #endregion
    }
}
