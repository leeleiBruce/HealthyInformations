using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
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
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.FrameWork.AuthorUser;
using HealthyInfomation.Resource;
using System.ComponentModel;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// SanatoriumCreate.xaml 的交互逻辑
    /// </summary>
    public partial class SanatoriumCreate : WindowBase
    {
        bool dialogResult = false;
        SanatoriumFacade sanatoriumFacade;
        public SanatoriumCreate()
        {
            InitializeComponent();
            this.SanatoriumModel = new SanatoriumModel();
            this.sanatoriumFacade = new SanatoriumFacade(this);
            this.DataContext = this;
        }

        #region viewModel

        private SanatoriumModel sanatoriumModel;
        public SanatoriumModel SanatoriumModel
        {
            get
            {
                return sanatoriumModel;
            }
            set
            {
                sanatoriumModel = value;
                RaisePropertyChanged("SanatoriumModel");
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
                    this.CreateSanatorium();
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

        private void ResetData()
        {
            this.SanatoriumModel.Name = string.Empty;
            this.SanatoriumModel.Address = string.Empty;
            this.SanatoriumModel.ContactPhone = string.Empty;
            this.SanatoriumModel.RecommendTravelMode = string.Empty;
        }

        private async void CreateSanatorium()
        {
            if (SanatoriumModel.HasValidationError()) return;

            var request = new SanatoriumRequest
            {
                Name = this.SanatoriumModel.Name.Trim(),
                Address = this.SanatoriumModel.Address.Trim(),
                ContactPhone = this.SanatoriumModel.ContactPhone.Trim(),
                RecommendTravelMode = this.SanatoriumModel.RecommendTravelMode.Trim(),
                ActionUserID = CPApplication.CurrentUser.UserName
            };

            await this.sanatoriumFacade.CreateSanatorium(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            this.ResetData();
            this.dialogResult = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.DialogResult = this.dialogResult;
        }

        #endregion
    }
}
