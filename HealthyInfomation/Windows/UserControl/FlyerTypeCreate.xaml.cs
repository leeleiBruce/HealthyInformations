using System.Windows.Input;
using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.FrameWork;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork.AuthorUser;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// FlyerTypeManage.xaml 的交互逻辑
    /// </summary>
    public partial class FlyerTypeCreate : WindowBase
    {
        ConfigDictionaryFacade facade;
        FlyerTypeEntity flyerTypeEntity;
        public FlyerTypeCreate()
        {
            InitializeComponent();
            this.facade = new ConfigDictionaryFacade(this);
            this.DataContext = this;
        }

        public FlyerTypeCreate(FlyerTypeEntity flyerType)
            : this()
        {
            flyerTypeEntity = flyerType;
            FlyerTypeName = flyerTypeEntity.TypeName;
        }

        private string flyerTypeName;
        public string FlyerTypeName
        {
            get
            {
                return flyerTypeName;
            }
            set
            {
                flyerTypeName = value;
                RaisePropertyChanged("FlyerTypeName");
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (flyerTypeEntity != null && flyerTypeEntity.TransactionNumber > 0)
                    {
                        this.UpdateFlyerType();
                    }
                    else
                    {
                        this.CreateFlyerType();
                    }
                });
            }
        }

        private async void CreateFlyerType()
        {
            if (string.IsNullOrWhiteSpace(FlyerTypeName))
            {
                this.ShowMessage("飞机名称不能为空");
                return;
            }

            var request = new FlyerTypeEntity { TypeName = FlyerTypeName, ActionUserID = CPApplication.CurrentUser.UserName };
            await this.facade.CreateFlyerType(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            this.DialogResult = true;
        }

        private async void UpdateFlyerType()
        {
            if (string.IsNullOrWhiteSpace(FlyerTypeName))
            {
                this.ShowMessage("飞机名称不能为空");
                return;
            }

            var request = new FlyerTypeEntity
            {
                TransactionNumber = flyerTypeEntity.TransactionNumber,
                TypeName = FlyerTypeName,
                ActionUserID = CPApplication.CurrentUser.UserName
            };
            await this.facade.UpdateFlyerType(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            this.DialogResult = true;
        }
    }
}
