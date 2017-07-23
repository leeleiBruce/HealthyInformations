using HealthyInfomation.Facade;
using HealthyInfomation.Windows.UserControl;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HealthyInfomation.Resource;
using System.Windows;
using System.Threading.Tasks;
using HealthyInfomation.Windows.PhysicalExam;

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// UserRegister.xaml 的交互逻辑
    /// </summary>
    public partial class AircrewManage : WindowBase
    {
        AircrewFacade aircrewFacade;
        public AircrewManage()
        {
            InitializeComponent();
            this.aircrewFacade = new AircrewFacade(this);
            this.AircrewSearchModel = new AircrewSearchModel();
            this.DataContext = this;
            this.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                this.SearchAircrewList();
            };
        }

        #region ViewModel

        private AircrewSearchModel aircrewSearchModel;
        public AircrewSearchModel AircrewSearchModel
        {
            get
            {
                return aircrewSearchModel;
            }
            set
            {
                aircrewSearchModel = value;
                RaisePropertyChanged("AircrewSearchModel");
            }
        }

        #endregion

        #region Command
        public ICommand NewCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.NewAircrew();
                });
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.SearchAircrewList();
                });
            }
        }

        public ICommand ViewDetailCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.ShowDetail(obj);
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.RemoveAircrew();
                });
            }
        }

        public ICommand PhysicalExamMaxCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (!this.CheckSelectAircrew()) return;
                    var selectedAircrew = this.AircrewSearchModel.AircrewList.FirstOrDefault();
                    new PhysicalExamMain(selectedAircrew).ShowDialog();
                });
            }
        }

        public ICommand PhysicalExamMinCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (!this.CheckSelectAircrew()) return;

                    var selectedAircrew = this.AircrewSearchModel.AircrewList.FirstOrDefault();
                    new PhysicalExamMin(selectedAircrew).ShowDialog();
                });
            }
        }

        public ICommand MedicalTreatmentCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (!this.CheckSelectAircrew()) return;

                    var selectedAircrew = this.AircrewSearchModel.AircrewList.FirstOrDefault();
                    new MedicalTreatment(selectedAircrew).ShowDialog();
                });
            }
        }

        public ICommand DiscomfortLevelCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (!this.CheckSelectAircrew()) return;

                    var selectedAircrew = this.AircrewSearchModel.AircrewList.FirstOrDefault();
                    new FlightDiscomfortLevel(selectedAircrew).ShowDialog();
                });
            }
        }

        public ICommand FlightAccidentCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (!this.CheckSelectAircrew()) return;

                    var selectedAircrew = this.AircrewSearchModel.AircrewList.FirstOrDefault();
                    new AviationAccident(selectedAircrew).ShowDialog();
                });
            }
        }

        #endregion

        #region method

        private bool CheckSelectAircrew()
        {
            if (AircrewSearchModel.AircrewList == null)
            {
                this.ShowWarning(AircrewResource.Msg_NoSelect);
                return false;
            }

            var selectedAircrew = this.AircrewSearchModel.AircrewList.Where(a => a.IsChecked).ToList();
            if (AircrewSearchModel.AircrewList == null || selectedAircrew.Count == 0)
            {
                this.ShowWarning(AircrewResource.Msg_NoSelect);
                return false;
            }

            if (selectedAircrew.Count > 1)
            {
                this.ShowWarning(AircrewResource.Msg_SelectOverflow);
                return false;
            }

            return true;
        }

        private async void SearchAircrewList(int pageIndex = 0, int pageSize = ConstDefinations.DEFAULT_PAGESIZE)
        {
            string name = (this.AircrewSearchModel.Name ?? string.Empty).Trim();
            var response = await this.aircrewFacade.GetAircrewList(name, AircrewSearchModel.StartDate.GetValueOrDefault(DateTime.MinValue), AircrewSearchModel.EndDate.GetValueOrDefault(DateTime.MaxValue), pageIndex, pageSize);
            this.AircrewSearchModel.AircrewList = new ObservableCollection<AircrewEntity>(response.AircrewList);
            int totalPages = response.TotalCount % pageSize == 0 ? response.TotalCount / pageSize : response.TotalCount / pageSize + 1;
            this.AircrewSearchModel.TotalCount = response.TotalCount;
            this.AircrewSearchModel.PageIndex = response.TotalCount>0? 1:0;
            this.AircrewSearchModel.HasPreviousPage = AircrewSearchModel.PageIndex > 1;
            this.AircrewSearchModel.HasNextPage = AircrewSearchModel.PageIndex < totalPages;
        }

        private void NewAircrew()
        {
            if (new AircrewCreate().ShowDialog().GetValueOrDefault(false))
            {
                this.SearchAircrewList();
            }
        }

        private void ShowDetail(object obj)
        {
            AircrewEntity entity = obj as AircrewEntity;
            if (new AircrewUpdate(entity).ShowDialog().GetValueOrDefault(false))
            {
                this.SearchAircrewList();
            }
        }

        private async Task RemoveAircrew()
        {
            if (this.AircrewSearchModel.SelectedAircrew == null
                || this.AircrewSearchModel.AircrewList == null
                || this.AircrewSearchModel.AircrewList.Count == 0) return;

            var removeAircrewList = this.AircrewSearchModel.AircrewList.Where(c => c.IsChecked).ToList();
            if (removeAircrewList.Count == 0)
            {
                this.ShowWarning(CommonMsgResource.Msg_NoRemoveData);
                return;
            }

            if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) != MessageBoxResult.Yes) return;

            foreach (var removeAircrew in removeAircrewList)
            {
                await this.aircrewFacade.RemoveAircrew(removeAircrew.TransactionNumber);
            }

            this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
            this.SearchAircrewList();
        }

        #endregion
    }
}
