using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
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

namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// AviationAccident.xaml 的交互逻辑
    /// </summary>
    public partial class AviationAccident : WindowBase
    {
        AviationAccidentFacade aviationAccidentFacade;
        AviationMedicineFacade aviationMedicineFacade;
        public AviationAccident()
        {
            InitializeComponent();
        }

        public AviationAccident(AircrewEntity entity)
            : this()
        {
            this.AviationAccidentModel = new AviationAccidentModel();
            this.DataContext = this;
            this.aviationAccidentFacade = new AviationAccidentFacade(this);
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.InitAviationMedicine();
        }

        #region ViewModel

        private AviationAccidentModel aviationAccidentModel;
        public AviationAccidentModel AviationAccidentModel
        {
            get
            {
                return aviationAccidentModel;
            }
            set
            {
                aviationAccidentModel = value;
                RaisePropertyChanged("AviationAccidentModel");
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
                    this.CreateAviationAccident();
                });
            }
        }

        #endregion

        #region Method

        private async Task InitAviationMedicine()
        {
            var response = await this.aviationMedicineFacade.GetAviationMedicineList(null, 0, 1000);
            if (response != null && response.AviationMedicineList != null)
            {
                response.AviationMedicineList.Insert(0, new AviationMedicineEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
                this.AviationMedicineList = response.AviationMedicineList;
            }
        }

        private async void CreateAviationAccident()
        {
            var request = AutoMapper.Mapper.Map<AviationAccidentRequest>(this.AviationAccidentModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            var response = await this.aviationAccidentFacade.CreateAviationAccident(request);
            if (response.IsSucess)
            {
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            }
            else
            {
                this.ShowMessage(response.ErrorMessage);
            }
        }

        #endregion
    }
}
