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
    /// AviationMedicine.xaml 的交互逻辑
    /// </summary>
    public partial class AviationMedicine : WindowBase
    {
        DispatcherTimer doubleClickTimer;
        AviationMedicineFacade aviationMedicineFacade;
        public AviationMedicine()
        {
            InitializeComponent();
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.AviationMedicineSearchModel = new AviationMedicineSearchModel();
            this.DataContext = this;
            this.InitTimer();
            this.InitTriggerAction();
            this.Loaded += (obj, args) =>
            {
                this.SearchAviationMedicine();
            };
        }

        #region viewModel

        private AviationMedicineSearchModel aviationMedicineSearchModel;
        public AviationMedicineSearchModel AviationMedicineSearchModel
        {
            get
            {
                return aviationMedicineSearchModel;
            }
            set
            {
                aviationMedicineSearchModel = value;
                RaisePropertyChanged("AviationMedicineSearchModel");
            }
        }

        #endregion

        #region Command

        public ICommand NewCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.NewAviationMedicine();
                });
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.SearchAviationMedicine();
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand(async (obj) =>
                {
                    await this.RemoveAviationMedicine();
                });
            }
        }

        #endregion

        #region Method

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
            this.DG_AviationMedicine.AttchEventTriggerAction(new BaseTrigger<DependencyObject, CommonDisease>((obj) =>
            {
                if (this.AviationMedicineSearchModel.SelectedAviationMedicine == null) return;

                if (doubleClickTimer.IsEnabled)
                {
                    doubleClickTimer.Stop();
                    var commonDiseaseUpdate = new AviationMedicineUpdate(AviationMedicineSearchModel.SelectedAviationMedicine);
                    if (commonDiseaseUpdate.ShowDialog().GetValueOrDefault(false))
                    {
                        this.SearchAviationMedicine();
                    }
                }
                else
                {
                    doubleClickTimer.Start();
                }
            }), EventEnums.MouseLeftButtonDown.ToString());
        }

        private void NewAviationMedicine()
        {
            var aviationMedicineCreate = new AviationMedicineCreate();
            aviationMedicineCreate.ShowDialog();
            this.SearchAviationMedicine();
        }

        private async void SearchAviationMedicine(int pageIndex = 0, int pageSize = ConstDefinations.DEFAULT_PAGESIZE)
        {
            string name = AviationMedicineSearchModel.Name ?? string.Empty;
            var result = await this.aviationMedicineFacade.GetAviationMedicineList(name.Trim(), pageIndex, pageSize);
            this.AviationMedicineSearchModel.AviationMedicineList = new ObservableCollection<AviationMedicineEntity>(result.AviationMedicineList);
        }

        private async Task RemoveAviationMedicine()
        {
            if (this.AviationMedicineSearchModel.AviationMedicineList == null
                || this.AviationMedicineSearchModel.AviationMedicineList == null
                || this.AviationMedicineSearchModel.AviationMedicineList.Count == 0)
                return;

            var removeAviationMedicineList = this.AviationMedicineSearchModel.AviationMedicineList.Where(c => c.IsChecked).ToList();
            if (removeAviationMedicineList.Count == 0)
            {
                this.ShowWarning(AviationMedicineResource.Msg_NoCheckedRemove);
                return;
            }

            if (this.ShowConfirm(AviationMedicineResource.Msg_RemoveConfirm) != MessageBoxResult.Yes) return;

            foreach (var removeAviationMedicine in removeAviationMedicineList)
            {
                await this.aviationMedicineFacade.RemoveAviationMedicine(removeAviationMedicine.TransactionNumber);
            }

            this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
            this.SearchAviationMedicine();
        }
        #endregion
    }
}
