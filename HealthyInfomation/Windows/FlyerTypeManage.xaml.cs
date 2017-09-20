using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using HealthyInformation.FrameWork.ActionTrigger;
using HealthyInformation.FrameWork.Enums;
using HealthyInfomation.Resource;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// FlyerTypeManage.xaml 的交互逻辑
    /// </summary>
    public partial class FlyerTypeManage : WindowBase
    {
        DispatcherTimer doubleClickTimer;
        ConfigDictionaryFacade facade;
        public FlyerTypeManage()
        {
            InitializeComponent();
            this.DataContext = this;
            facade = new ConfigDictionaryFacade(this);
            this.Loaded += FlyerTypeManage_Loaded;
            InitTriggerAction();
            this.InitTimer();
        }

        private void FlyerTypeManage_Loaded(object sender, RoutedEventArgs e)
        {
            InitFlyerTypeList();
        }

        #region model

        private List<FlyerTypeEntity> flyerTypeList;
        public List<FlyerTypeEntity> FlyerTypeList
        {
            get
            {
                return flyerTypeList;
            }
            set
            {
                flyerTypeList = value;
                RaisePropertyChanged("FlyerTypeList");
            }
        }

        private FlyerTypeEntity currentFlyerTypeEntity;
        public FlyerTypeEntity CurrentFlyerTypeEntity
        {
            get
            {
                return currentFlyerTypeEntity;
            }
            set
            {
                currentFlyerTypeEntity = value;
                RaisePropertyChanged("CurrentFlyerTypeEntity");
            }
        }

        #endregion

        #region Command
        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand(async (obj) =>
                {
                    if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
                    {
                        var flyerType = obj as FlyerTypeEntity;
                        await this.facade.DeleteFlyerType(flyerType.TransactionNumber);
                        this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                        this.InitFlyerTypeList();
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
                    var dialogResult = new FlyerTypeCreate().ShowDialog();
                    if (dialogResult.GetValueOrDefault(false))
                    {
                        this.InitFlyerTypeList();
                    }
                });
            }
        }

        private async void InitFlyerTypeList()
        {
            FlyerTypeList = await facade.GetFlyerTypeList();
        }

        #endregion
        private void InitTriggerAction()
        {
            this.DG_FlyerType.AttchEventTriggerAction(new BaseTrigger<DependencyObject, CommonDisease>((obj) =>
            {
                if (this.CurrentFlyerTypeEntity == null) return;

                if (doubleClickTimer.IsEnabled)
                {
                    doubleClickTimer.Stop();
                    var flyerTypeCreate = new FlyerTypeCreate(this.CurrentFlyerTypeEntity);
                    if (flyerTypeCreate.ShowDialog().GetValueOrDefault(false))
                    {
                        this.InitFlyerTypeList();
                    }
                }
                else
                {
                    doubleClickTimer.Start();
                }
            }), EventEnums.MouseLeftButtonDown.ToString());
        }

        private void InitTimer()
        {
            doubleClickTimer = new DispatcherTimer();
            doubleClickTimer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            doubleClickTimer.Tick += new EventHandler(DoubleClick_Timer);
        }
        private void DoubleClick_Timer(object sender, EventArgs e)
        {
            doubleClickTimer.Stop();
        }
    }
}
