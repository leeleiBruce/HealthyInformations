using HealthyInfomation.Facade;
using HealthyInfomation.Windows.UserControl;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Windows.Threading;
using HealthyInformation.FrameWork.ActionTrigger;
using HealthyInformation.FrameWork.Enums;
using HealthyInfomation.Resource;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// Sanatorium.xaml 的交互逻辑
    /// </summary>
    public partial class Sanatorium : WindowBase
    {
        DispatcherTimer doubleClickTimer;
        SanatoriumFacade sanatoriumFacade;
        public Sanatorium()
        {
            InitializeComponent();
            this.sanatoriumFacade = new SanatoriumFacade(this);
            this.SanatoriumSearchModel = new SanatoriumSearchModel();
            this.DataContext = this;
            this.Loaded += (obj, args) => 
            {
                this.InitTimer();
                this.InitTriggerAction();
                this.SearchSanatorium();
            };
        }

        #region property

        private SanatoriumSearchModel sanatoriumSearchModel;
        public SanatoriumSearchModel SanatoriumSearchModel
        {
            get
            {
                return sanatoriumSearchModel;
            }
            set
            {
                sanatoriumSearchModel = value;
                RaisePropertyChanged("SanatoriumSearchModel");
            }
        }

        #endregion

        #region Command

        public ICommand SearchCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.SearchSanatorium();
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

        public ICommand NewCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.NewSanatorium();
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.RemoveSanatorium();
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
            this.DG_Sanatorium.AttchEventTriggerAction(new BaseTrigger<DependencyObject, CommonDisease>((obj) =>
            {
                if (this.SanatoriumSearchModel.SelectedSanatorium == null) return;

                if (doubleClickTimer.IsEnabled)
                {
                    doubleClickTimer.Stop();
                    var sanatoriumUpdate = new SanatoriumUpdate(SanatoriumSearchModel.SelectedSanatorium);
                    if (sanatoriumUpdate.ShowDialog().GetValueOrDefault(false))
                    {
                        this.SearchSanatorium();
                    }
                }
                else
                {
                    doubleClickTimer.Start();
                }
            }), EventEnums.MouseLeftButtonDown.ToString());
        }

        private async void SearchSanatorium(int pageIndex = 0, int pageSize = ConstDefinations.DEFAULT_PAGESIZE)
        {
            string name = this.SanatoriumSearchModel.Name ?? string.Empty;
            var result = await this.sanatoriumFacade.GetSanatoriumList(name.Trim(), pageIndex, pageSize);
            this.SanatoriumSearchModel.SanatoriumEntityList = new ObservableCollection<SanatoriumEntity>(result.SanatoriumList);
        }

        private void NewSanatorium()
        {
            bool? dialogResult = new SanatoriumCreate().ShowDialog();
            if (dialogResult.GetValueOrDefault(false))
            {
                this.SearchSanatorium();
            }
        }

        private async void RemoveSanatorium()
        {
            if (this.SanatoriumSearchModel.SanatoriumEntityList == null
                || this.SanatoriumSearchModel.SanatoriumEntityList.Count == 0) return;

            var selectedSanatoriumList = this.SanatoriumSearchModel.SanatoriumEntityList.Where(s => s.IsChecked).ToList();
            if (selectedSanatoriumList.Count == 0)
            {
                this.ShowMessage(CommonMsgResource.Msg_NoRemoveData);
                return;
            }

            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) != MessageBoxResult.Yes) return;

            foreach (var sanatorium in selectedSanatoriumList)
            {
                await this.sanatoriumFacade.DeleteSanatorium(sanatorium.TransactionNumber);
            }

            this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
            this.SearchSanatorium();
        }
        #endregion
    }
}
