using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.ClientEntity.PhysicalExam.ViewModel;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.AuthorUser;
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
namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// PhysicalExamMin.xaml 的交互逻辑
    /// </summary>
    public partial class PhysicalExamMin : WindowBase
    {
        PhysicalExamMinFacade facade;
        AviationMedicineFacade aviationMedicineFacade;
        AircrewEntity currentAircrew;
        public PhysicalExamMin()
        {
            InitializeComponent();
            this.PhysicalExamMinModel = new PhysicalExamMinModel();
            this.facade = new PhysicalExamMinFacade(this);
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.DataContext = this;
            this.InitData();
        }

        public PhysicalExamMin(AircrewEntity aircrewEntity)
            : this()
        {
            this.currentAircrew = aircrewEntity;
        }

        #region property

        private PhysicalExamMinModel physicalExamMinModel;
        public PhysicalExamMinModel PhysicalExamMinModel
        {
            get
            {
                return physicalExamMinModel;
            }
            set
            {
                physicalExamMinModel = value;
                RaisePropertyChanged("PhysicalExamMinModel");
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

        #region command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.CreatePhysicalExamMin();
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

        #endregion

        #region Method

        private async void InitData()
        {
            var response = await this.aviationMedicineFacade.GetAviationMedicineList(string.Empty, 0, 1000);
            response.AviationMedicineList.Insert(0, new AviationMedicineEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
            this.AviationMedicineList = response.AviationMedicineList;
            this.PhysicalExamMinModel.AviationMedicineID = 0;
        }

        private async void CreatePhysicalExamMin()
        {
            if (this.PhysicalExamMinModel.HasValidationError()) return;

            var request = new PhysicalExamMinRecordRequest
            {
                AircrewID = currentAircrew.TransactionNumber,
                ActionUserID = CPApplication.CurrentUser.UserName,
                AviationMedicineID = physicalExamMinModel.AviationMedicineID.Value,
                BloodPressure = physicalExamMinModel.BloodPressure.Value,
                Conclusion = physicalExamMinModel.Conclusion,
                Pulse = physicalExamMinModel.Pulse.Value,
                RecordDate = physicalExamMinModel.RecordDate.Value,
                VisionLeft = physicalExamMinModel.VisionLeft.Value,
                VisionRight = physicalExamMinModel.VisionRight.Value,
                Weight = physicalExamMinModel.Weight.Value
            };

            await this.facade.CreatePhysicalExamMin(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        #endregion
    }
}
