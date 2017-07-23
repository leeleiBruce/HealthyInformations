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
    /// SupplementaryExam.xaml 的交互逻辑
    /// </summary>
    public partial class SupplementaryExam : WindowBase
    {
        PhysicalExamMaxFacade physicalExamMaxFacade;
        AircrewEntity aircrewEntity;
        public SupplementaryExam()
        {
            InitializeComponent();
        }

        public SupplementaryExam(AircrewEntity aircrewEntity, int year)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
            this.DataContext = this;
            this.physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            this.InitData(year);
        }

        #region ViewModel

        private SupplementaryExamModel supplementaryExamModel;
        public SupplementaryExamModel SupplementaryExamModel
        {
            get
            {
                return supplementaryExamModel;
            }
            set
            {
                supplementaryExamModel = value;
                RaisePropertyChanged("SupplementaryExamModel");
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
                    if (this.SupplementaryExamModel.TransactionNumber > 0)
                    {
                        this.UpdateSupplementaryExam();
                    }
                    else
                    {
                        this.CreateSupplementaryExam();
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
                    RemoveSupplementaryExam();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData(int year)
        {
            this.RemoveVisibility = Visibility.Collapsed;
            var supplementaryExam = await this.physicalExamMaxFacade.GetSupplementaryExam(aircrewEntity.TransactionNumber, year);
            if (supplementaryExam != null)
            {
                this.SupplementaryExamModel = AutoMapper.Mapper.Map<SupplementaryExamEntity, SupplementaryExamModel>(supplementaryExam);
                this.RemoveVisibility = Visibility.Visible;
            }
            else
            {
                this.SupplementaryExamModel = new SupplementaryExamModel();
            }
        }

        private async void CreateSupplementaryExam()
        {
            if (this.SupplementaryExamModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<SupplementaryExamRequest>(SupplementaryExamModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = this.aircrewEntity.TransactionNumber;
            await physicalExamMaxFacade.CreateSupplementaryExam(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdateSupplementaryExam()
        {
            if (this.SupplementaryExamModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<SupplementaryExamRequest>(SupplementaryExamModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            request.AircrewID = this.aircrewEntity.TransactionNumber;
            request.TransactionNumber = this.SupplementaryExamModel.TransactionNumber;
            await physicalExamMaxFacade.UpdateSupplementaryExam(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void RemoveSupplementaryExam()
        {
            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
            {
                await this.physicalExamMaxFacade.RemoveSupplementaryExam(SupplementaryExamModel.TransactionNumber);
                this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                this.SupplementaryExamModel = new SupplementaryExamModel();
                this.RemoveVisibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
