using HealthyInformation.ClientEntity.PhysicalExam.ViewModel;
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
using HealthyInformation.FrameWork.Extension;
using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// FlightDiscomfortLevel.xaml 的交互逻辑
    /// </summary>
    public partial class FlightDiscomfortLevel : WindowBase
    {
        int dataIndex = 0;
        int minYear = 2010;
        AircrewEntity entity;
        AviationMedicineFacade aviationMedicineFacade;
        FlightDiscomfortLevelFacade flightDiscomfortLevelFacade;
        ConfigDictionaryFacade configDictionaryFacade;
        List<FlightDiscomfortLevelEntity> flightDiscomfortLevelList;

        public FlightDiscomfortLevel()
        {
            InitializeComponent();
            this.FlightDiscomfortLevelModel = new FlightDiscomfortLevelModel();
            this.DataContext = this;
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.flightDiscomfortLevelFacade = new FlightDiscomfortLevelFacade(this);
            this.configDictionaryFacade = new ConfigDictionaryFacade(this);
            this.PropertyChanged += FlightDiscomfortLevel_PropertyChanged;
        }

        public FlightDiscomfortLevel(AircrewEntity entity)
            : this()
        {
            this.entity = entity;
            this.InitData();
        }

        #region viewModel

        private FlightDiscomfortLevelModel flightDiscomfortLevelModel;
        public FlightDiscomfortLevelModel FlightDiscomfortLevelModel
        {
            get
            {
                return flightDiscomfortLevelModel;
            }
            set
            {
                flightDiscomfortLevelModel = value;
                RaisePropertyChanged("FlightDiscomfortLevelModel");
            }
        }

        private List<AviationMedicineEntity> aviationMedicineList;
        public List<AviationMedicineEntity> AviationMedicineList
        {
            get
            {
                return aviationMedicineList;
            }
            set
            {
                aviationMedicineList = value;
                RaisePropertyChanged("AviationMedicineList");
            }
        }

        private List<FlyerTypeEntity> flyerTypeEntityList;
        public List<FlyerTypeEntity> FlyerTypeEntityList
        {
            get
            {
                return flyerTypeEntityList;
            }
            set
            {
                flyerTypeEntityList = value;
                RaisePropertyChanged("FlyerTypeEntityList");
            }
        }

        private int selectedYear;
        public int SelectedYear
        {
            get
            {
                return selectedYear;
            }
            set
            {
                selectedYear = value;
                RaisePropertyChanged("SelectedYear");
            }
        }

        private Visibility updateVisibility;
        public Visibility UpdateVisibility
        {
            get
            {
                return updateVisibility;
            }
            set
            {
                updateVisibility = value;
                RaisePropertyChanged("UpdateVisibility");
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

        private bool isUpdateEnabled;
        public bool IsUpdateEnabled
        {
            get
            {
                return isUpdateEnabled;
            }
            set
            {
                isUpdateEnabled = value;
                RaisePropertyChanged("IsUpdateEnabled");
            }
        }

        private bool isRemoveEnabled;
        public bool IsRemoveEnabled
        {
            get
            {
                return isRemoveEnabled;
            }
            set
            {
                isRemoveEnabled = value;
                RaisePropertyChanged("IsRemoveEnabled");
            }
        }

        private bool isPreviousEnabled;
        public bool IsPreviousEnabled
        {
            get
            {
                return isPreviousEnabled;
            }
            set
            {
                isPreviousEnabled = value;
                RaisePropertyChanged("IsPreviousEnabled");
            }
        }

        private bool isNextEnabled;
        public bool IsNextEnabled
        {
            get
            {
                return isNextEnabled;
            }
            set
            {
                isNextEnabled = value;
                RaisePropertyChanged("IsNextEnabled");
            }
        }

        public List<KeyValuePair<int, string>> YearList
        {
            get
            {
                var years = new List<KeyValuePair<int, string>>();
                years.Add(new KeyValuePair<int, string>(0, CommonResource.Default_Select));
                var yearRange = Enumerable.Range(minYear, DateTime.Now.Year - minYear + 1);
                IEnumerator<int> yearEnumerator = yearRange.GetEnumerator();
                while (yearEnumerator.MoveNext())
                {
                    years.Add(new KeyValuePair<int, string>(yearEnumerator.Current, string.Concat(yearEnumerator.Current, " 年")));
                }
                return years.OrderByDescending(y => y.Key).ToList();
            }
        }

        #endregion

        #region Command

        public ICommand UpdateCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.IsSaveEnabled = true;
                    this.IsUpdateEnabled = false;
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.FlightDiscomfortLevelModel.TransactionNumber > 0)
                    {
                        this.UpdateFlightDiscomfortable();
                    }
                    else
                    {
                        this.CreateFlightDiscomfortable();
                    }
                });
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (flightDiscomfortLevelList == null || flightDiscomfortLevelList.Count == 0) return;
                    this.dataIndex -= 1;
                    if (dataIndex == 0)
                    {
                        IsNextEnabled = true;
                        IsPreviousEnabled = false;
                    }

                    this.FlightDiscomfortLevelModel = AutoMapper.Mapper.Map<FlightDiscomfortLevelModel>(flightDiscomfortLevelList[dataIndex]);
                });
            }
        }

        public ICommand NextCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (flightDiscomfortLevelList == null || flightDiscomfortLevelList.Count == 0) return;
                    this.dataIndex += 1;
                    if (dataIndex == flightDiscomfortLevelList.Count - 1)
                    {
                        IsNextEnabled = false;
                    }
                    else
                    {
                        IsPreviousEnabled = true;
                    }

                    this.FlightDiscomfortLevelModel = AutoMapper.Mapper.Map<FlightDiscomfortLevelModel>(flightDiscomfortLevelList[dataIndex]);
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return CommandFactory.CreateCommand(async (obj) =>
                {
                    if (FlightDiscomfortLevelModel == null) return;

                    if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
                    {
                        this.flightDiscomfortLevelFacade.DeleteFlightDiscomfortLevel(FlightDiscomfortLevelModel.TransactionNumber);
                        this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                        await this.RefreshUIData();
                    }
                });
            }
        }

        #endregion

        #region Method

        private async void InitData()
        {
            this.IsSaveEnabled = true;
            this.IsRemoveEnabled = false;
            this.UpdateVisibility = Visibility.Collapsed;
            await this.InitAviationMedicine();
            this.InitFlyerType();
        }

        private async Task InitAviationMedicine()
        {
            var response = await this.aviationMedicineFacade.GetAviationMedicineList(null, 0, 1000);
            if (response != null && response.AviationMedicineList != null)
            {
                response.AviationMedicineList.Insert(0, new AviationMedicineEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
                this.AviationMedicineList = response.AviationMedicineList;
            }
        }

        private async void InitFlyerType()
        {
            var flyerTypeList = await this.configDictionaryFacade.GetFlyerTypeList();
            if (flyerTypeList != null)
            {
                flyerTypeList.Insert(0, new FlyerTypeEntity
                {
                    TransactionNumber = 0,
                    TypeName = CommonResource.Default_Select
                });
            }

            this.FlyerTypeEntityList = flyerTypeList;
            this.FlightDiscomfortLevelModel.FlyerType = 0;
        }

        private async void CreateFlightDiscomfortable()
        {
            if (this.FlightDiscomfortLevelModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<FlightDiscomfortLevelRequest>(this.FlightDiscomfortLevelModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            var response = await this.flightDiscomfortLevelFacade.CreateFlightDiscomfortLevel(request);
            if (response != null)
            {
                if (response.IsSucess)
                {
                    this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                    await this.RefreshUIData();
                }
                else
                {
                    this.ShowMessage(response.ErrorMessage);
                }
            }
        }

        private async void UpdateFlightDiscomfortable()
        {
            if (this.FlightDiscomfortLevelModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<FlightDiscomfortLevelRequest>(this.FlightDiscomfortLevelModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            var response = await this.flightDiscomfortLevelFacade.UpdateFlightDiscomfortLevel(request);
            if (response != null)
            {
                if (response.IsSucess)
                {
                    this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                    await this.RefreshUIData();
                }
                else
                {
                    this.ShowMessage(response.ErrorMessage);
                }
            }
        }

        #endregion

        private async void FlightDiscomfortLevel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedYear")
            {
                await RefreshUIData();
            }
        }

        private async Task RefreshUIData()
        {
            dataIndex = 0;
            flightDiscomfortLevelList = await this.flightDiscomfortLevelFacade.GetFlightDiscomfortLevelByYear(SelectedYear);
            if (flightDiscomfortLevelList == null || flightDiscomfortLevelList.Count == 0)
            {
                this.UpdateVisibility = Visibility.Collapsed;
                this.IsSaveEnabled = true;
                this.IsRemoveEnabled = false;
                this.FlightDiscomfortLevelModel = new FlightDiscomfortLevelModel();
            }
            else
            {
                this.UpdateVisibility = Visibility.Visible;
                this.IsUpdateEnabled = true;
                this.IsRemoveEnabled = true;
                this.IsSaveEnabled = false;
                this.FlightDiscomfortLevelModel = AutoMapper.Mapper.Map<FlightDiscomfortLevelModel>(flightDiscomfortLevelList[0]);
            }

            this.IsPreviousEnabled = false;
            this.IsNextEnabled = flightDiscomfortLevelList != null && flightDiscomfortLevelList.Count > 1;
        }
    }
}
