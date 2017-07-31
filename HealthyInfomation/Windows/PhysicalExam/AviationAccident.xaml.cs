using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;
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
        int dataIndex = 0;
        int minYear = 2010;
        AviationAccidentFacade aviationAccidentFacade;
        AviationMedicineFacade aviationMedicineFacade;
        List<AviationAccidentEntity> aviationAccidentList;

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
            this.InitData();
            this.PropertyChanged += AviationAccident_PropertyChanged;
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


        private int selectedYear;
        public int SelectedYear
        {
            get
            {
                return selectedYear;
            }
            set
            {
                selectedYear = value;
                RaisePropertyChanged("SelectedYear");
            }
        }

        private Visibility updateVisibility;
        public Visibility UpdateVisibility
        {
            get
            {
                return updateVisibility;
            }
            set
            {
                updateVisibility = value;
                RaisePropertyChanged("UpdateVisibility");
            }
        }

        private bool isSaveEnabled;
        public bool IsSaveEnabled
        {
            get
            {
                return isSaveEnabled;
            }
            set
            {
                isSaveEnabled = value;
                RaisePropertyChanged("IsSaveEnabled");
            }
        }

        private bool isUpdateEnabled;
        public bool IsUpdateEnabled
        {
            get
            {
                return isUpdateEnabled;
            }
            set
            {
                isUpdateEnabled = value;
                RaisePropertyChanged("IsUpdateEnabled");
            }
        }

        private bool isRemoveEnabled;
        public bool IsRemoveEnabled
        {
            get
            {
                return isRemoveEnabled;
            }
            set
            {
                isRemoveEnabled = value;
                RaisePropertyChanged("IsRemoveEnabled");
            }
        }

        private bool isPreviousEnabled;
        public bool IsPreviousEnabled
        {
            get
            {
                return isPreviousEnabled;
            }
            set
            {
                isPreviousEnabled = value;
                RaisePropertyChanged("IsPreviousEnabled");
            }
        }

        private bool isNextEnabled;
        public bool IsNextEnabled
        {
            get
            {
                return isNextEnabled;
            }
            set
            {
                isNextEnabled = value;
                RaisePropertyChanged("IsNextEnabled");
            }
        }

        public List<KeyValuePair<int, string>> YearList
        {
            get
            {
                var years = new List<KeyValuePair<int, string>>();
                years.Add(new KeyValuePair<int, string>(0, CommonResource.Default_Select));
                var yearRange = Enumerable.Range(minYear, DateTime.Now.Year - minYear + 1);
                IEnumerator<int> yearEnumerator = yearRange.GetEnumerator();
                while (yearEnumerator.MoveNext())
                {
                    years.Add(new KeyValuePair<int, string>(yearEnumerator.Current, string.Concat(yearEnumerator.Current, " 年")));
                }
                return years.OrderByDescending(y => y.Key).ToList();
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
                    if (AviationAccidentModel.TransactionNumber > 0)
                    {
                        UpdateAviationAccident();
                    }
                    else
                    {
                        CreateAviationAccident();
                    }
                });
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.IsSaveEnabled = true;
                    this.IsUpdateEnabled = false;
                });
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (aviationAccidentList == null || aviationAccidentList.Count == 0) return;
                    this.dataIndex -= 1;
                    if (dataIndex == 0)
                    {
                        IsNextEnabled = true;
                        IsPreviousEnabled = false;
                    }

                    this.AviationAccidentModel = AutoMapper.Mapper.Map<AviationAccidentModel>(aviationAccidentList[dataIndex]);
                });
            }
        }

        public ICommand NextCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (aviationAccidentList == null || aviationAccidentList.Count == 0) return;
                    this.dataIndex += 1;
                    if (dataIndex == aviationAccidentList.Count - 1)
                    {
                        IsNextEnabled = false;
                    }
                    else
                    {
                        IsPreviousEnabled = true;
                    }

                    this.AviationAccidentModel = AutoMapper.Mapper.Map<AviationAccidentModel>(aviationAccidentList[dataIndex]);
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return CommandFactory.CreateCommand(async (obj) =>
                {
                    if (AviationAccidentModel == null) return;

                    if (this.ShowConfirm(CommonMsgResource.Msg_RemoveConfirm) == MessageBoxResult.Yes)
                    {
                        this.aviationAccidentFacade.DeleteAviationAccident(AviationAccidentModel.TransactionNumber);
                        this.ShowMessage(CommonMsgResource.Msg_RemoveSuccess);
                        await this.RefreshUIData();
                    }
                });
            }
        }

        #endregion

        #region Method

        private void InitData()
        {
            this.IsSaveEnabled = true;
            this.IsRemoveEnabled = false;
            this.UpdateVisibility = Visibility.Collapsed;
        }

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
                await RefreshUIData();
            }
            else
            {
                this.ShowMessage(response.ErrorMessage);
            }
        }

        private async void UpdateAviationAccident()
        {
            var request = AutoMapper.Mapper.Map<AviationAccidentRequest>(this.AviationAccidentModel);
            request.ActionUserID = CPApplication.CurrentUser.UserName;
            var response = await this.aviationAccidentFacade.UpdateAviationAccident(request);
            if (response.IsSucess)
            {
                this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                await RefreshUIData();
            }
            else
            {
                this.ShowMessage(response.ErrorMessage);
            }
        }

        private async Task RefreshUIData()
        {
            dataIndex = 0;
            aviationAccidentList = await this.aviationAccidentFacade.GetAviationAccidentByYear(SelectedYear);
            if (aviationAccidentList == null || aviationAccidentList.Count == 0)
            {
                this.UpdateVisibility = Visibility.Collapsed;
                this.IsSaveEnabled = true;
                this.IsRemoveEnabled = false;
                this.AviationAccidentModel = new AviationAccidentModel();
            }
            else
            {
                this.UpdateVisibility = Visibility.Visible;
                this.IsUpdateEnabled = true;
                this.IsRemoveEnabled = true;
                this.IsSaveEnabled = false;
                this.AviationAccidentModel = AutoMapper.Mapper.Map<AviationAccidentModel>(aviationAccidentList[0]);
            }

            this.IsPreviousEnabled = false;
            this.IsNextEnabled = aviationAccidentList != null && aviationAccidentList.Count > 1;
        }

        #endregion

        private async void AviationAccident_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedYear")
            {
                await RefreshUIData();
            }
        }
    }
}
