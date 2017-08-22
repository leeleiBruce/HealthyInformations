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
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInfomation.Resource;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// ENTSection.xaml 的交互逻辑
    /// </summary>
    public partial class ENTSection : WindowBase
    {
        AircrewEntity aircrewEntity;
        AviationMedicineFacade aviationMedicineFacade;
        PhysicalExamMaxFacade physicalExamMaxFacade;
        public ENTSection()
        {
            InitializeComponent();
        }

        public ENTSection(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.DataContext = this;
            this.InitData(year);
        }

        #region ViewModel

        private ENTSectionModel _ENTSectionModel;
        public ENTSectionModel ENTSectionModel
        {
            get
            {
                return _ENTSectionModel;
            }
            set
            {
                _ENTSectionModel = value;
                RaisePropertyChanged("ENTSectionModel");
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

        #endregion

        #region Command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (ENTSectionModel.TransactionNumber > 0)
                    {
                        this.UpdateENTSection();
                    }
                    else
                    {
                        this.CreateENTSection();
                    }
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    RemoveENTSection();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData(int year)
        {
            this.RemoveVisibility = Visibility.Collapsed;
            await InitAviationMedicine();
            var _ENTSection = await this.physicalExamMaxFacade.GetENTSection(aircrewEntity.TransactionNumber, year);
            if (_ENTSection != null)
            {
                this.ENTSectionModel = AutoMapper.Mapper.Map<ENTSectionEntity, ENTSectionModel>(_ENTSection);
                this.RemoveVisibility = Visibility.Visible;
            }
            else
            {
                this.ENTSectionModel = new ENTSectionModel();
                this.ENTSectionModel.AviationMedicineID = 0;
            }
        }

        private async Task InitAviationMedicine()
        {
            var response = await aviationMedicineFacade.GetAviationMedicineList(string.Empty, 0, 2000);
            response.AviationMedicineList.Insert(0, new AviationMedicineEntity
            {
                TransactionNumber = 0,
                Name = CommonResource.Default_Select
            });
            this.AviationMedicineList = response.AviationMedicineList;
        }

        private async void RemoveENTSection()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.physicalExamMaxFacade.RemoveENTSection(ENTSectionModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.ENTSectionModel = new ENTSectionModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        public async void CreateENTSection()
        {
            if (this.ENTSectionModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<ENTSectionModel, ENTSectionRequest>(ENTSectionModel);
            request.AircrewID = aircrewEntity.TransactionNumber;
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            await this.physicalExamMaxFacade.CreateENTSection(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        public async void UpdateENTSection()
        {
            if (this.ENTSectionModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<ENTSectionModel, ENTSectionRequest>(ENTSectionModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.TransactionNumber = this.ENTSectionModel.TransactionNumber;
            await this.physicalExamMaxFacade.CreateENTSection(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        #endregion
    }
}
