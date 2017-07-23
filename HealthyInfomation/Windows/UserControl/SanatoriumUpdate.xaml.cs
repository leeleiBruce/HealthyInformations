using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInfomation.Resource;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInformation.ClientEntity.SystemManage.Entity;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// SanatoriumUpdate.xaml 的交互逻辑
    /// </summary>
    public partial class SanatoriumUpdate : WindowBase
    {
        SanatoriumFacade sanatoriumFacade;
        SanatoriumEntity sanatoriumEntity;

        public SanatoriumUpdate()
        {
            InitializeComponent();
        }

        public SanatoriumUpdate(SanatoriumEntity sanatoriumEntity)
            : this()
        {
            this.sanatoriumEntity = sanatoriumEntity;
            this.sanatoriumFacade = new SanatoriumFacade(this);
            this.DataContext = this;
            this.Loaded += (obj, args) =>
            {
                InitData();
            };
        }

        #region viewModel

        private SanatoriumModel sanatoriumModel;
        public SanatoriumModel SanatoriumModel
        {
            get
            {
                return sanatoriumModel;
            }
            set
            {
                sanatoriumModel = value;
                RaisePropertyChanged("SanatoriumModel");
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

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.UpdateSanatorium();
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

        public ICommand EditCommand
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

        #endregion

        #region Method

        private void InitData()
        {
            this.SanatoriumModel = AutoMapper.Mapper.Map<SanatoriumEntity, SanatoriumModel>(this.sanatoriumEntity);
            this.IsEditEnabled = true;
            this.IsSaveEnabled = false;
        }

        private async void UpdateSanatorium()
        {
            if (SanatoriumModel.HasValidationError()) return;

            var request = new SanatoriumRequest
            {
                TransactionNumber = this.sanatoriumEntity.TransactionNumber,
                Name = this.SanatoriumModel.Name.Trim(),
                Address = this.SanatoriumModel.Address.Trim(),
                ContactPhone = this.SanatoriumModel.ContactPhone.Trim(),
                RecommendTravelMode = this.SanatoriumModel.RecommendTravelMode.Trim(),
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            await this.sanatoriumFacade.UpdateSanatorium(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            this.DialogResult = true;
        }

        #endregion
    }
}
