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

namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// MedicalTreatment.xaml 的交互逻辑
    /// </summary>
    public partial class MedicalTreatment : WindowBase
    {
        AircrewEntity aircrewEntity;
        MedicalTreatmentFacade facade;
        public MedicalTreatment()
        {
            InitializeComponent();
            this.MedicalTreatmentModel = new MedicalTreatmentModel();
            this.DataContext = this;
            this.facade = new MedicalTreatmentFacade(this);
            this.MedicalTreatmentModel.NeedObservation = true;
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

        #endregion

        public MedicalTreatment(AircrewEntity aircrewEntity)
            : this()
        {
            this.aircrewEntity = aircrewEntity;
        }

        #region Command

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

        public ICommand SaveCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.CreateMedicalTreatment();
                });
            }
        }

        #endregion

        #region Method

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
    }
}
