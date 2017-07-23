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
using HealthyInformation.FrameWork.Extension;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Windows.PhysicalExam.UserControl
{
    /// <summary>
    /// OralCavity.xaml 的交互逻辑
    /// </summary>
    public partial class OralCavity : WindowBase
    {
        AircrewEntity aircrewEntity;
        PhysicalExamMaxFacade physicalExamMaxFacade;
        public OralCavity()
        {
            InitializeComponent();
        }

        public OralCavity(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.DataContext = this;
            this.InitData(year);
        }

        #region ViewModel

        private OralCavityModel oralCavityModel;
        public OralCavityModel OralCavityModel
        {
            get
            {
                return oralCavityModel;
            }
            set
            {
                oralCavityModel = value;
                RaisePropertyChanged("OralCavityModel");
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
                    if (this.OralCavityModel.TransactionNumber > 0)
                    {
                        this.UpdateOralCavity();
                    }
                    else
                    {
                        this.CreateOralCavity();
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
                    this.RemoveOralCavity();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData(int year)
        {
            this.RemoveVisibility = Visibility.Collapsed;
            var oralCavity = await this.physicalExamMaxFacade.GetOralCavity(aircrewEntity.TransactionNumber, year);
            if (oralCavity != null)
            {
                this.OralCavityModel = AutoMapper.Mapper.Map<OralCavityEntity, OralCavityModel>(oralCavity);
                this.RemoveVisibility = Visibility.Visible;
            }
            else
            {
                this.OralCavityModel = new OralCavityModel();
            }
        }

        private async void CreateOralCavity()
        {
            if (this.OralCavityModel.HasValidationError()) return;

            var request = new OralCavityRequest
            {
                AircrewID = aircrewEntity.TransactionNumber,
                Suggestion = this.OralCavityModel.Suggestion,
                CheckOut = this.OralCavityModel.CheckOut,
                Conclusion = this.OralCavityModel.Conclusion,
                Diagnosis = this.OralCavityModel.Diagnosis,
                MedicalHistory = this.OralCavityModel.MedicalHistory,
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            await this.physicalExamMaxFacade.CreateOralCavity(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdateOralCavity()
        {
            if (this.OralCavityModel.HasValidationError()) return;

            var request = new OralCavityRequest
            {
                TransactionNumber = this.OralCavityModel.TransactionNumber,
                Suggestion = this.OralCavityModel.Suggestion,
                CheckOut = this.OralCavityModel.CheckOut,
                Conclusion = this.OralCavityModel.Conclusion,
                Diagnosis = this.OralCavityModel.Diagnosis,
                MedicalHistory = this.OralCavityModel.MedicalHistory,
                ActionUserID = CPApplication.CurrentUser.UserName,
                AircrewID = aircrewEntity.TransactionNumber
            };

            await this.physicalExamMaxFacade.UpdateOralCavity(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void RemoveOralCavity()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.physicalExamMaxFacade.RemoveOralCavity(OralCavityModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.OralCavityModel = new OralCavityModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }
        #endregion
    }
}
