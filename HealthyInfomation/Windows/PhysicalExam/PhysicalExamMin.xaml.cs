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
using System.Windows;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// PhysicalExamMin.xaml 的交互逻辑
    /// </summary>
    public partial class PhysicalExamMin : WindowBase
    {
        int minYear = 2010;
        PhysicalExamMinFacade facade;
        AviationMedicineFacade aviationMedicineFacade;
        AircrewEntity currentAircrew;
        public PhysicalExamMin()
        {
            InitializeComponent();
            this.PhysicalExamMinModel = new PhysicalExamMinModel();
            this.facade = new PhysicalExamMinFacade(this);
            this.aviationMedicineFacade = new AviationMedicineFacade(this);
            this.DataContext = this;
            this.InitData();
            this.PropertyChanged += PhysicalExamMin_PropertyChanged;
        }

        public PhysicalExamMin(AircrewEntity aircrewEntity)
            : this()
        {
            this.currentAircrew = aircrewEntity;
        }

        #region property

        private PhysicalExamMinModel physicalExamMinModel;
        public PhysicalExamMinModel PhysicalExamMinModel
        {
            get
            {
                return physicalExamMinModel;
            }
            set
            {
                physicalExamMinModel = value;
                RaisePropertyChanged("PhysicalExamMinModel");
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

        #region command

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.PhysicalExamMinModel.TransactionNumber > 0)
                    {
                        this.UpdatePhysicalExam();
                    }
                    else
                    {
                        this.CreatePhysicalExamMin();
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

        #endregion

        #region Method

        private async void InitData()
        {
            this.IsSaveEnabled = true;
            this.UpdateVisibility = Visibility.Collapsed;
            var response = await this.aviationMedicineFacade.GetAviationMedicineList(string.Empty, 0, 1000);
            response.AviationMedicineList.Insert(0, new AviationMedicineEntity { TransactionNumber = 0, Name = CommonResource.Default_Select });
            this.AviationMedicineList = response.AviationMedicineList;
            this.PhysicalExamMinModel.AviationMedicineID = 0;
        }

        private async void CreatePhysicalExamMin()
        {
            if (this.PhysicalExamMinModel.HasValidationError()) return;

            var request = BuildRequest();
            await this.facade.CreatePhysicalExamMin(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
        }

        private async void UpdatePhysicalExam()
        {
            if (this.PhysicalExamMinModel.HasValidationError()) return;

            var request = BuildRequest();
            await this.facade.UpdatePhysicalExamMin(request);
            this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
            this.IsSaveEnabled = false;
        }

        private PhysicalExamMinRecordRequest BuildRequest()
        {
            return new PhysicalExamMinRecordRequest
            {
                TransactionNumber = PhysicalExamMinModel.TransactionNumber,
                AircrewID = currentAircrew.TransactionNumber,
                ActionUserID = CPApplication.CurrentUser.UserName,
                AviationMedicineID = physicalExamMinModel.AviationMedicineID.Value,
                BloodPressure = physicalExamMinModel.BloodPressure.Value,
                Conclusion = physicalExamMinModel.Conclusion,
                Pulse = physicalExamMinModel.Pulse.Value,
                RecordDate = physicalExamMinModel.RecordDate.Value,
                VisionLeft = physicalExamMinModel.VisionLeft.Value,
                VisionRight = physicalExamMinModel.VisionRight.Value,
                Weight = physicalExamMinModel.Weight.Value
            };
        }

        #endregion

        #region Event

        private async void PhysicalExamMin_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedYear")
            {
                var physicalExamMin = await this.facade.GetPhysicalExamMinByYear(SelectedYear);
                this.PhysicalExamMinModel = AutoMapper.Mapper.Map<PhysicalExamMinModel>(physicalExamMin);
                if (physicalExamMin != null)
                {
                    this.UpdateVisibility = Visibility.Visible;
                    this.IsUpdateEnabled = true;
                    this.IsSaveEnabled = false;
                }
                else
                {
                    this.PhysicalExamMinModel = new PhysicalExamMinModel();
                    this.UpdateVisibility = Visibility.Collapsed;
                    this.IsSaveEnabled = true;
                }
            }
        }

        #endregion
    }
}
