using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInfomation.Windows.UserControl;
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

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// RecuperationPlan.xaml 的交互逻辑
    /// </summary>
    public partial class RecuperationPlan : WindowBase
    {
        SanatoriumFacade sanatoriumFacade;
        RecuperationInformationFacade recuperationFacade;
        public RecuperationPlan()
        {
            InitializeComponent();
            recuperationFacade = new RecuperationInformationFacade(this);
            sanatoriumFacade = new SanatoriumFacade(this);
            DataContext = this;
            InitData();
        }

        #region ViewModel

        private int sanatoriumID;
        public int SanatoriumID
        {
            get
            {
                return sanatoriumID;
            }
            set
            {
                sanatoriumID = value;
                RaisePropertyChanged("SanatoriumID");
            }
        }

        private DateTime? startDate;
        public DateTime? StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        private DateTime? endDate;
        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        private UP_GetRecuperationPlan_Result selectedRecuperationPlan;
        public UP_GetRecuperationPlan_Result SelectedRecuperationPlan
        {
            get
            {
                return selectedRecuperationPlan;
            }
            set
            {
                selectedRecuperationPlan = value;
                RaisePropertyChanged("SelectedRecuperationPlan");
            }
        }

        private List<UP_GetRecuperationPlan_Result> recuperationPlanList;
        public List<UP_GetRecuperationPlan_Result> RecuperationPlanList
        {
            get
            {
                return recuperationPlanList;
            }
            set
            {
                recuperationPlanList = value;
                RaisePropertyChanged("RecuperationPlanList");
            }
        }

        private List<SanatoriumEntity> sanatoriumList;
        public List<SanatoriumEntity> SanatoriumList
        {
            get
            {
                return sanatoriumList;
            }
            set
            {
                sanatoriumList = value;
                RaisePropertyChanged("SanatoriumList");
            }
        }

        #endregion

        #region Command

        public ICommand SearchCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.SearchRecuperationPlan();
                });
            }
        }

        public ICommand NewCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    new RecuperationInformation().ShowDialog();
                });
            }
        }

        public ICommand ModifyCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var recuperation = obj as UP_GetRecuperationPlan_Result;
                    new RecuperationInformationModify(recuperation.TransactionNumber).ShowDialog();
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand(async (obj) =>
                {
                    if (ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
                    {
                        var recuperation = obj as UP_GetRecuperationPlan_Result;
                        await this.recuperationFacade.RemoveRecuperationInformation(recuperation.TransactionNumber);
                        ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                    }
                });
            }
        }

        public ICommand PrintCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var recuperation = obj as UP_GetRecuperationPlan_Result;
                    new RecuperationPrint(recuperation.TransactionNumber).ShowDialog();
                });
            }
        }

        #endregion

        #region Method

        private async void InitData()
        {
            var response = await sanatoriumFacade.GetSanatoriumList(string.Empty, 0, 1000);
            if (response != null)
            {
                response.SanatoriumList.Insert(0, new SanatoriumEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
                this.SanatoriumList = response.SanatoriumList;
            }
        }

        private async void SearchRecuperationPlan()
        {
            RecuperationPlanList = await recuperationFacade.GetRecuperationPlanList(this.SanatoriumID, this.StartDate, this.EndDate);
        }

        #endregion
    }
}
