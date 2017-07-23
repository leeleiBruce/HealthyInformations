using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
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
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// InternalMedicine.xaml 的交互逻辑
    /// </summary>
    public partial class InternalMedicine : WindowBase
    {
        AircrewEntity aircrewEntity;
        AviationMedicineFacade aviationMedicineFacade;
        PhysicalExamMaxFacade physicalExamMaxFacade;
        public InternalMedicine()
        {
            InitializeComponent();
        }

        public InternalMedicine(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.DataContext = this;
            this.InitData(year);
        }

        #region ViewModel

        private InternalMedicineModel internalMedicineModel;
        public InternalMedicineModel InternalMedicineModel
        {
            get
            {
                return internalMedicineModel;
            }
            set
            {
                internalMedicineModel = value;
                RaisePropertyChanged("InternalMedicineModel");
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
                    if (this.InternalMedicineModel.TransactionNumber > 0)
                    {
                        UpdateInternalMedicine();
                    }
                    else
                    {
                        CreateInternalMedicine();
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
                    RemoveInternalMedicine();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData(int year)
        {
            this.RemoveVisibility = Visibility.Collapsed;
            var response = await this.aviationMedicineFacade.GetAviationMedicineList(string.Empty, 0, 1000);
            response.AviationMedicineList.Insert(0, new AviationMedicineEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
            this.AviationMedicineList = response.AviationMedicineList;

            var internalMedicine = await this.physicalExamMaxFacade.GetInternalMedicine(aircrewEntity.TransactionNumber, year);
            if (internalMedicine != null)
            {
                this.InternalMedicineModel = AutoMapper.Mapper.Map<InternalMedicineEntity, InternalMedicineModel>(internalMedicine);
                this.RemoveVisibility = Visibility.Visible;
            }
            else
            {
                this.InternalMedicineModel = new InternalMedicineModel();
                this.InternalMedicineModel.AviationMedicineID = 0;
            }
        }

        private async void CreateInternalMedicine()
        {
            if (this.InternalMedicineModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<InternalMedicineRequest>(InternalMedicineModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = aircrewEntity.TransactionNumber;
            await this.physicalExamMaxFacade.CreateInternalMedicine(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdateInternalMedicine()
        {
            if (this.InternalMedicineModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<InternalMedicineRequest>(InternalMedicineModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.TransactionNumber = InternalMedicineModel.TransactionNumber;
            await this.physicalExamMaxFacade.UpdateInternalMedicine(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void RemoveInternalMedicine()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.physicalExamMaxFacade.RemoveInternalMedicine(InternalMedicineModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.InternalMedicineModel = new InternalMedicineModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
