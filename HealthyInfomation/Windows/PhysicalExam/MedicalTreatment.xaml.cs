using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.ClientEntity.PhysicalExam.ViewModel;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.AuthorUser;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using HealthyInformation.FrameWork.Extension;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// MedicalTreatment.xaml 的交互逻辑
    /// </summary>
    public partial class MedicalTreatment : WindowBase
    {
        int minYear = 2010;
        AircrewEntity aircrewEntity;
        MedicalTreatmentFacade facade;
        public MedicalTreatment()
        {
            InitializeComponent();
            this.MedicalTreatmentModel = new MedicalTreatmentModel();
            this.DataContext = this;
            this.facade = new MedicalTreatmentFacade(this);
            this.MedicalTreatmentModel.NeedObservation = true;
            this.InitData();
            this.MedicalTreatmentModel.PropertyChanged += MedicalTreatmentModel_PropertyChanged;
        }

        #region property

        private MedicalTreatmentModel medicalTreatmentModel;
        public MedicalTreatmentModel MedicalTreatmentModel
        {
            get
            {
                return medicalTreatmentModel;
            }
            set
            {
                medicalTreatmentModel = value;
                RaisePropertyChanged("MedicalTreatmentModel");
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

        public MedicalTreatment(AircrewEntity aircrewEntity)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
        }

        #region Command

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

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    if (this.MedicalTreatmentModel.TransactionNumber > 0)
                    {
                        this.UpdateMedicalTreatment();
                    }
                    else
                    {
                        this.CreateMedicalTreatment();
                    }
                });
            }
        }

        #endregion

        #region Method

        private void InitData()
        {
            this.IsSaveEnabled = true;
            this.UpdateVisibility = Visibility.Collapsed;
        }

        public async void CreateMedicalTreatment()
        {
            if (this.MedicalTreatmentModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<MedicalTreatmentRequest>(MedicalTreatmentModel);
            request.AircrewID = this.aircrewEntity.TransactionNumber;
            request.ActionUserID = CPApplication.CurrentUser.UserName;

            if (!this.CheckData())
            {
                return;
            }

            var response = await this.facade.CreateMedicalTreatment(request);
            if (response != null)
            {
                if (response.IsSucess)
                {
                    this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                }
                else
                {
                    this.ShowWarning(response.ErrorMessage);
                }
            }
        }

        private async void UpdateMedicalTreatment()
        {
            if (this.MedicalTreatmentModel.HasValidationError()) return;

            var request = AutoMapper.Mapper.Map<MedicalTreatmentRequest>(MedicalTreatmentModel);
            request.AircrewID = this.aircrewEntity.TransactionNumber;
            request.ActionUserID = CPApplication.CurrentUser.UserName;

            if (!this.CheckData())
            {
                return;
            }

            var response = await this.facade.UpdateMedicalTreatment(request);
            if (response != null)
            {
                if (response.IsSucess)
                {
                    this.ShowMessage(CommonMsgResource.Msg_SaveSuccess);
                }
                else
                {
                    this.ShowWarning(response.ErrorMessage);
                }
            }
        }

        private bool CheckData()
        {
            if (this.MedicalTreatmentModel.NeedObservation)
            {
                if (!MedicalTreatmentModel.ObservationStartDate.HasValue)
                {
                    this.ShowWarning(MedicalTreatmentResource.Msg_StartDateEmpty);
                    return false;
                }

                if (!MedicalTreatmentModel.ObservationEndDate.HasValue)
                {
                    this.ShowWarning(MedicalTreatmentResource.Msg_EndDateEmpty);
                    return false;
                }

                if (MedicalTreatmentModel.ObservationStartDate >= MedicalTreatmentModel.ObservationEndDate)
                {
                    this.ShowMessage(MedicalTreatmentResource.Msg_StartDateLaterThanEnd);
                    return false;
                }
            }

            return true;
        }

        #endregion

        private async void MedicalTreatmentModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedYear")
            {
                var medicalTreatment = await this.facade.GetMedicalTreatmentByYear(SelectedYear);
                this.MedicalTreatmentModel = AutoMapper.Mapper.Map<MedicalTreatmentModel>(medicalTreatment);
                if (medicalTreatment != null)
                {
                    this.UpdateVisibility = Visibility.Visible;
                    this.IsUpdateEnabled = true;
                    this.IsSaveEnabled = false;
                }
                else
                {
                    this.MedicalTreatmentModel = new MedicalTreatmentModel();
                    this.UpdateVisibility = Visibility.Collapsed;
                    this.IsSaveEnabled = true;
                }
            }
        }
    }
}
