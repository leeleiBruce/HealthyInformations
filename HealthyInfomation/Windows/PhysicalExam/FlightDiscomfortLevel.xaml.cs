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

namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// FlightDiscomfortLevel.xaml 的交互逻辑
    /// </summary>
    public partial class FlightDiscomfortLevel : WindowBase
    {
        AircrewEntity entity;
        AviationMedicineFacade aviationMedicineFacade;
        FlightDiscomfortLevelFacade flightDiscomfortLevelFacade;
        ConfigDictionaryFacade configDictionaryFacade;

        public FlightDiscomfortLevel()
        {
            InitializeComponent();
            this.FlightDiscomfortLevelModel = new FlightDiscomfortLevelModel();
            this.DataContext = this;
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.flightDiscomfortLevelFacade = new FlightDiscomfortLevelFacade(this);
            this.configDictionaryFacade = new ConfigDictionaryFacade(this);
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

        #endregion

        #region Command

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

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.CreateFlightDiscomfortable();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData()
        {
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
                }
                else
                {
                    this.ShowMessage(response.ErrorMessage);
                }
            }
        }

        #endregion
    }
}
