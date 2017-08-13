using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using HealthyInformation.FrameWork.Extension;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// FlyRecord.xaml 的交互逻辑
    /// </summary>
    public partial class FlyRecord : WindowBase
    {
        ConfigDictionaryFacade configDictionaryFacade;
        public FlyRecord()
        {
            InitializeComponent();
            this.configDictionaryFacade = new ConfigDictionaryFacade(this);
            this.DataContext = this;
            this.FlightRecordList = new ObservableCollection<FlightRecordEntity>();
            this.InitData();
        }

        public FlyRecord(List<FlightRecordEntity> flightRecordList)
        {
            InitializeComponent();
            this.configDictionaryFacade = new ConfigDictionaryFacade(this);
            this.InitData();
            this.DataContext = this;
            this.FlightRecordList = new ObservableCollection<FlightRecordEntity>(flightRecordList);
            this.Closing += FlyRecord_Closing;
        }

        #region ViewModel

        private ObservableCollection<FlightRecordEntity> flightRecordList;
        public ObservableCollection<FlightRecordEntity> FlightRecordList
        {
            get
            {
                return flightRecordList;
            }
            set
            {
                flightRecordList = value;
                RaisePropertyChanged("FlightRecordList");
            }
        }

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

        #endregion

        #region Command

        public ICommand NewCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.FlightRecordList.Add(new FlightRecordEntity { FlightType = "0" });
                });
            }
        }

        public ICommand EnsureCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.FlightRecordList != null && this.FlightRecordList.Any(f => f.HasValidationError())) return;
                    this.Close();
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var flightRecord = obj as FlightRecordEntity;
                    if (flightRecord != null)
                    {
                        this.FlightRecordList.Remove(flightRecord);
                    }
                });
            }
        }
        #endregion

        #region Method

        private async void InitData()
        {
            var flyerTypes = await configDictionaryFacade.GetFlyerTypeList();
            flyerTypes.Insert(0, new FlyerTypeEntity { TransactionNumber = 0, TypeName = CommonResource.Default_Select });
            this.FlyerTypeList = flyerTypes;
        }

        private void FlyRecord_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.FlightRecordList != null && this.FlightRecordList.Any(f => f.HasValidationError()))
                e.Cancel = true;
        }

        #endregion
    }
}
