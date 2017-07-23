using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
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
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// Neuropsychiatry.xaml 的交互逻辑
    /// </summary>
    public partial class Neuropsychiatry : WindowBase
    {
        AircrewEntity aircrewEntity;
        AviationMedicineFacade aviationMedicineFacade;
        PhysicalExamMaxFacade physicalExamMaxFacade;
        public Neuropsychiatry()
        {
            InitializeComponent();
        }

        public Neuropsychiatry(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.DataContext = this;
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.InitData(year);
        }

        #region View Model

        private NeuropsychiatryModel neuropsychiatryModel;
        public NeuropsychiatryModel NeuropsychiatryModel
        {
            get
            {
                return neuropsychiatryModel;
            }
            set
            {
                neuropsychiatryModel = value;
                RaisePropertyChanged("NeuropsychiatryModel");
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
                    if (this.NeuropsychiatryModel.TransactionNumber > 0)
                    {
                        UpdateNeuropsychiatry();
                    }
                    else
                    {
                        CreateNeuropsychiatry();
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
                    RemoveNeuropsychiatry();
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

            var neuropsychiatry = await this.physicalExamMaxFacade.GetNeuropsychiatry(aircrewEntity.TransactionNumber, year);
            if (neuropsychiatry != null)
            {
                this.RemoveVisibility = Visibility.Visible;
                this.NeuropsychiatryModel = AutoMapper.Mapper.Map<NeuropsychiatryEntity, NeuropsychiatryModel>(neuropsychiatry);
            }
            else
            {
                this.NeuropsychiatryModel = new NeuropsychiatryModel();
                this.NeuropsychiatryModel.AviationMedicineID = 0;
            }
        }

        private async void CreateNeuropsychiatry()
        {
            if (this.NeuropsychiatryModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<NeuropsychiatryRequest>(this.NeuropsychiatryModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = aircrewEntity.TransactionNumber;
            await this.physicalExamMaxFacade.CreateNeuropsychiatry(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdateNeuropsychiatry()
        {
            if (this.NeuropsychiatryModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<NeuropsychiatryRequest>(this.NeuropsychiatryModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.TransactionNumber = this.NeuropsychiatryModel.TransactionNumber;
            await this.physicalExamMaxFacade.UpdateNeuropsychiatry(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void RemoveNeuropsychiatry()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.physicalExamMaxFacade.RemoveNeuropsychiatry(NeuropsychiatryModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.NeuropsychiatryModel = new NeuropsychiatryModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
