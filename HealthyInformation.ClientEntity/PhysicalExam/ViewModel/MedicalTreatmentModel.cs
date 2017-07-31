using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class MedicalTreatmentModel : ModelBase
    {
        private DateTime? hospitalizationDate;
        [Required(ErrorMessage = "入院日期不能为空！")]
        public DateTime? HospitalizationDate
        {
            get
            {
                return hospitalizationDate;
            }
            set
            {
                hospitalizationDate = value;
                RaisePropertyChanged("HospitalizationDate");
            }
        }

        private DateTime? dischargeDate;
        [Required(ErrorMessage = "出院日期不能为空！")]
        public DateTime? DischargeDate
        {
            get
            {
                return dischargeDate;
            }
            set
            {
                dischargeDate = value;
                RaisePropertyChanged("DischargeDate");
            }
        }

        private string hospitalLocation;
        [Required(ErrorMessage = "送医地点不能为空！")]
        public string HospitalLocation
        {
            get
            {
                return hospitalLocation;
            }
            set
            {
                hospitalLocation = value;
                RaisePropertyChanged("HospitalLocation");
            }
        }

        private string hospitalReason;
        [Required(ErrorMessage = "送医原因不能为空！")]
        public string HospitalReason
        {
            get
            {
                return hospitalReason;
            }
            set
            {
                hospitalReason = value;
                RaisePropertyChanged("HospitalReason");
            }
        }

        private string checkSituation;
        [Required(ErrorMessage = "检查情况不能为空！")]
        public string CheckSituation
        {
            get
            {
                return checkSituation;
            }
            set
            {
                checkSituation = value;
                RaisePropertyChanged("CheckSituation");
            }
        }

        private string diagnosis;
        [Required(ErrorMessage = "诊断不能为空！")]
        public string Diagnosis
        {
            get
            {
                return diagnosis;
            }
            set
            {
                diagnosis = value;
                RaisePropertyChanged("Diagnosis");
            }
        }

        private string conclusion;
        [Required(ErrorMessage = "结论不能为空！")]
        public string Conclusion
        {
            get
            {
                return conclusion;
            }
            set
            {
                conclusion = value;
                RaisePropertyChanged("Conclusion");
            }
        }

        private bool needObservation;
        public bool NeedObservation
        {
            get
            {
                return needObservation;
            }
            set
            {
                needObservation = value;
                NotNeedObervation = !value;
                RaisePropertyChanged("NotNeedObervation");
                RaisePropertyChanged("NeedObservation");
            }
        }

        private bool notNeedObservation;
        public bool NotNeedObervation
        {
            get
            {
                return notNeedObservation;
            }
            set
            {
                notNeedObservation = value;
                RaisePropertyChanged("NotNeedObervation");
            }
        }

        private DateTime? observationStartDate;
        public DateTime? ObservationStartDate
        {
            get
            {
                return observationStartDate;
            }
            set
            {
                observationStartDate = value;
                RaisePropertyChanged("ObservationStartDate");
            }
        }

        private DateTime? observationEndDate;
        public DateTime? ObservationEndDate
        {
            get
            {
                return observationEndDate;
            }
            set
            {
                observationEndDate = value;
                RaisePropertyChanged("ObservationEndDate");
            }
        }

        private DateTime? recordDate;
        [Required(ErrorMessage="日期不能为空！")]
        public DateTime? RecordDate
        {
            get 
            {
                return recordDate;
            }
            set
            {
                recordDate = value;
                RaisePropertyChanged("RecordDate");
            }
        }
    }
}
