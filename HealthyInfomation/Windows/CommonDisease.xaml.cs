using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInfomation.Windows.UserControl;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ActionTrigger;
using HealthyInformation.FrameWork.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// CommonDisease.xaml 的交互逻辑
    /// </summary>
    public partial class CommonDisease : WindowBase
    {
        DispatcherTimer doubleClickTimer;
        CommonDiseaseFacade commonDiseaseFacade;
        public CommonDisease()
        {
            InitializeComponent();
            this.commonDiseaseFacade = new CommonDiseaseFacade(this);
            this.CommonDiseaseModel = new CommonDiseaseSearchModel();
            this.DataContext = this;
            this.InitTriggerAction();
            this.InitTimer();
            this.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                this.SearchDisease();
            };
        }

        #region ViewModel

        private CommonDiseaseSearchModel commonDiseaseModel;
        public CommonDiseaseSearchModel CommonDiseaseModel
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


        public ICommand SearchCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.SearchDisease();
                });
            }
        }

        public ICommand NewCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.NewCommonDisease();
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand(async (obj) =>
                {
                    await this.RemoveCommonDisease();
                });
            }
        }

        #endregion

        #region method

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

        private void InitTriggerAction()
        {
            this.DG_CommonDisease.AttchEventTriggerAction(new BaseTrigger<DependencyObject, CommonDisease>((obj) =>
            {
                if (this.CommonDiseaseModel.SelectedCommonDisease == null) return;

                if (doubleClickTimer.IsEnabled)
                {
                    doubleClickTimer.Stop();
                    var commonDiseaseUpdate = new CommonDiseaseUpdate(CommonDiseaseModel.SelectedCommonDisease);
                    if (commonDiseaseUpdate.ShowDialog().GetValueOrDefault(false))
                    {
                        this.SearchDisease();
                    }
                }
                else
                {
                    doubleClickTimer.Start();
                }
            }), EventEnums.MouseLeftButtonDown.ToString());
        }

        private async void SearchDisease(int pageIndex = 0, int pageSize = 10)
        {
            var result = await this.commonDiseaseFacade.GetCommonDiseaseList(CommonDiseaseModel.DiseaseName, pageIndex, pageSize);
            this.CommonDiseaseModel.CommonDiseaseList = new ObservableCollection<CommonDiseaseEntity>(result.CommonDiseaseList);
            this.CommonDiseaseModel.TotalCount = result.TotalCount;
        }

        private void NewCommonDisease()
        {
            var commonDiseaseCreate = new CommonDiseaseCreate();
            if (commonDiseaseCreate.ShowDialog().GetValueOrDefault(false))
            {
                this.SearchDisease();
            }
        }

        private async Task RemoveCommonDisease()
        {
            if (this.CommonDiseaseModel.CommonDiseaseList == null
                || this.CommonDiseaseModel.CommonDiseaseList.Count == 0)
                return;

            var removeCommonDiseaseList = this.CommonDiseaseModel.CommonDiseaseList.Where(c => c.IsChecked).ToList();
            if (removeCommonDiseaseList.Count == 0)
            {
                this.ShowWarning(CommonDiseaseResource.Msg_NoCheckedRemove);
                return;
            }

            if (this.ShowConfirm(CommonDiseaseResource.Msg_RemoveConfirm) != MessageBoxResult.Yes) return;

            foreach (var commonDisease in removeCommonDiseaseList)
            {
                await this.commonDiseaseFacade.RemoveCommonDisease(commonDisease.TransactionNumber);
            }

            this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
            this.SearchDisease();
        }
        #endregion
    }
}
