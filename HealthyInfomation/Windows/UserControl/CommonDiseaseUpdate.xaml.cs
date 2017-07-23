using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.FrameWork;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using System.Windows.Input;
using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInfomation.Resource;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// CommonDiseaseUpdate.xaml 的交互逻辑
    /// </summary>
    public partial class CommonDiseaseUpdate : WindowBase
    {
        CommonDiseaseEntity commonDiseaseEntity;
        CommonDiseaseFacade commonDiseaseFacade;
        public CommonDiseaseUpdate()
        {
            InitializeComponent();
        }

        public CommonDiseaseUpdate(CommonDiseaseEntity commonDiseaseEntity)
            : this()
        {
            this.commonDiseaseEntity = commonDiseaseEntity;
            this.commonDiseaseFacade = new CommonDiseaseFacade(this);
            this.DataContext = this;
            this.InitData();
        }

        #region ViewModel

        private CommonDiseaseModel commonDiseaseModel;
        public CommonDiseaseModel CommonDiseaseModel
        {
            get
            {
                return commonDiseaseModel;
            }
            set
            {
                commonDiseaseModel = value;
                RaisePropertyChanged("CommonDiseaseModel");
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

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.UpdateCommonDisease();
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

        #endregion

        #region method

        private void InitData()
        {
            this.CommonDiseaseModel = AutoMapper.Mapper.Map<CommonDiseaseEntity, CommonDiseaseModel>(commonDiseaseEntity);
            this.IsEditEnabled = true;
            this.IsSaveEnabled = false;
        }

        private void ResetData()
        {
            this.CommonDiseaseModel.SymptomDetail = string.Empty;
            this.CommonDiseaseModel.SymptomName = string.Empty;
            this.CommonDiseaseModel.TreatmentPlan = string.Empty;
            this.CommonDiseaseModel.Medication = string.Empty;
        }

        private async void UpdateCommonDisease()
        {
            if (CommonDiseaseModel.HasValidationError()) return;

            var commonDiseaseRequest = new CommonDiseaseRequest
            {
                TransactionNumber = CommonDiseaseModel.TransactionNumber,
                SymptomName = CommonDiseaseModel.SymptomName,
                SymptomDetail = CommonDiseaseModel.SymptomDetail,
                Medication = CommonDiseaseModel.Medication,
                TreatmentPlan = CommonDiseaseModel.TreatmentPlan,
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            var response = await this.commonDiseaseFacade.UpdateCommonDisease(commonDiseaseRequest);
            if (response.IsSucess)
            {
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                this.DialogResult = true;
            }
        }

        #endregion
    }
}
