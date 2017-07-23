using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            this.FlightRecordList = new ObservableCollection<FlightRecordEntity>();
            this.DataContext = this;
            this.InitData();
        }

        public FlyRecord(List<FlightRecordEntity> flightRecordList)
        {
            InitializeComponent();
            this.configDictionaryFacade = new ConfigDictionaryFacade(this);
            this.InitData();
            this.FlightRecordList = new ObservableCollection<FlightRecordEntity>(flightRecordList);
            this.DataContext = this;
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

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {

                    PrintDialog dialog = new PrintDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        dialog.PrintVisual(this, "Print Test");
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
            this.FlightRecordList.Add(new FlightRecordEntity { FlightType = "0" });
        }

        #endregion
    }
}
