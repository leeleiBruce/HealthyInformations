using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.AuthorUser;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
using HealthyInfomation.Resource;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// CommonDiseaseCreate.xaml 的交互逻辑
    /// </summary>
    public partial class CommonDiseaseCreate : WindowBase
    {
        CommonDiseaseFacade commonDiseaseFacade;
        public CommonDiseaseCreate()
        {
            InitializeComponent();
            this.commonDiseaseFacade = new CommonDiseaseFacade(this);
            this.CommonDiseaseCreateModel = new CommonDiseaseModel();
            this.DataContext = this;
        }

        private CommonDiseaseModel commonDiseaseCreateModel;
        public CommonDiseaseModel CommonDiseaseCreateModel
        {
            get
            {
                return commonDiseaseCreateModel;
            }
            set
            {
                commonDiseaseCreateModel = value;
                RaisePropertyChanged("CommonDiseaseCreateModel");
            }
        }

        #region Command
        public ICommand CloseCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.DialogResult = false;
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.CreateCommonDisease();
                });
            }
        }
        #endregion

        #region method
        private async void CreateCommonDisease()
        {
            if (CommonDiseaseCreateModel.HasValidationError()) return;

            var commonDiseaseRequest = new CommonDiseaseRequest
            {
                SymptomName = CommonDiseaseCreateModel.SymptomName,
                SymptomDetail = CommonDiseaseCreateModel.SymptomDetail,
                Medication = CommonDiseaseCreateModel.Medication,
                TreatmentPlan = CommonDiseaseCreateModel.TreatmentPlan,
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            var response = await this.commonDiseaseFacade.CreateCommonDisease(commonDiseaseRequest);
            if (!response.IsSucess)
            {
                this.ShowWarning(response.ErrorMessage);
                return;
            }

            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            this.ResetData();
        }

        private void ResetData()
        {
            this.CommonDiseaseCreateModel.SymptomDetail = string.Empty;
            this.CommonDiseaseCreateModel.SymptomName = string.Empty;
            this.CommonDiseaseCreateModel.TreatmentPlan = string.Empty;
            this.CommonDiseaseCreateModel.Medication = string.Empty;
        }
        #endregion
    }
}
