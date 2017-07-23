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
using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// SkinSurgery.xaml 的交互逻辑
    /// </summary>
    public partial class SkinSurgery : WindowBase
    {
        AircrewEntity aircrewEntity;
        PhysicalExamMaxFacade physicalExamMaxFacade;
        AviationMedicineFacade aviationMedicineFacade;

        public SkinSurgery()
        {
            InitializeComponent();
        }

        public SkinSurgery(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.DataContext = this;
            this.InitData(year);
        }

        #region ViewModel

        private SkinSurgeryModel skinSurgeryModel;
        public SkinSurgeryModel SkinSurgeryModel
        {
            get
            {
                return skinSurgeryModel;
            }
            set
            {
                skinSurgeryModel = value;
                RaisePropertyChanged("SkinSurgeryModel");
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
                    if (this.SkinSurgeryModel.TransactionNumber > 0)
                    {
                        UpdateSkinSurgery();
                    }
                    else
                    {
                        CreateSkinSurgery();
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
                    RemoveSkinSurgery();
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

            var result = await this.physicalExamMaxFacade.GetSkinSurgery(aircrewEntity.TransactionNumber, year);
            if (result == null)
            {
                this.SkinSurgeryModel = new SkinSurgeryModel();
                this.SkinSurgeryModel.AviationMedicineID = 0;
            }
            else
            {
                this.SkinSurgeryModel = AutoMapper.Mapper.Map<SkinSurgeryEntity, SkinSurgeryModel>(result);
                this.RemoveVisibility = Visibility.Visible;
            }
        }

        private async void CreateSkinSurgery()
        {
            if (SkinSurgeryModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<SkinSurgeryRequest>(SkinSurgeryModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = this.aircrewEntity.TransactionNumber;

            await physicalExamMaxFacade.CreateSkinSurgery(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdateSkinSurgery()
        {
            if (SkinSurgeryModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<SkinSurgeryRequest>(SkinSurgeryModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = this.aircrewEntity.TransactionNumber;

            await physicalExamMaxFacade.UpdateSkinSurgery(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void RemoveSkinSurgery()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await physicalExamMaxFacade.RemoveSkinSurgery(SkinSurgeryModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                this.SkinSurgeryModel = new SkinSurgeryModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
