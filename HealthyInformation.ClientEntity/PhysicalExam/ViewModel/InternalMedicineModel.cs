using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class InternalMedicineModel : ModelBase
    {
        public string pulseStatic;
        [Required(ErrorMessage = "不能为空！")]
        public string PulseStatic
        {
            get
            {
                return pulseStatic;
            }
            set
            {
                pulseStatic = value;
                RaisePropertyChanged("PulseStatic");
            }
        }

        public string pulseSquat;
        [Required(ErrorMessage = "不能为空！")]
        public string PulseSquat
        {
            get
            {
                return pulseSquat;
            }
            set
            {
                pulseSquat = value;
                RaisePropertyChanged("PulseSquat");
            }
        }

        public string pulseRest;
        [Required(ErrorMessage = "不能为空！")]
        public string PulseRest
        {
            get
            {
                return pulseRest;
            }
            set
            {
                pulseRest = value;
                RaisePropertyChanged("PulseRest");
            }
        }

        public string bloodPressureStatic;
        [Required(ErrorMessage = "不能为空！")]
        public string BloodPressureStatic
        {
            get
            {
                return bloodPressureStatic;
            }
            set
            {
                bloodPressureStatic = value;
                RaisePropertyChanged("BloodPressureStatic");
            }
        }

        public string bloodPressureSquat;
        [Required(ErrorMessage = "不能为空！")]
        public string BloodPressureSquat
        {
            get
            {
                return bloodPressureSquat;
            }
            set
            {
                bloodPressureSquat = value;
                RaisePropertyChanged("BloodPressureSquat");
            }
        }

        public string bloodPressureRest;
        [Required(ErrorMessage = "不能为空！")]
        public string BloodPressureRest
        {
            get
            {
                return bloodPressureRest;
            }
            set
            {
                bloodPressureRest = value;
                RaisePropertyChanged("BloodPressureRest");
            }
        }

        public string medicalHistory;
        [Required(ErrorMessage = "不能为空！")]
        public string MedicalHistory
        {
            get
            {
                return medicalHistory;
            }
            set
            {
                medicalHistory = value;
                RaisePropertyChanged("MedicalHistory");
            }
        }

        public string development;
        [Required(ErrorMessage = "不能为空！")]
        public string Development
        {
            get
            {
                return development;
            }
            set
            {
                development = value;
                RaisePropertyChanged("Development");
            }
        }

        public string skin;
        [Required(ErrorMessage = "不能为空！")]
        public string Skin
        {
            get
            {
                return skin;
            }
            set
            {
                skin = value;
                RaisePropertyChanged("Skin");
            }
        }

        public string lymphGland;
        [Required(ErrorMessage = "不能为空！")]
        public string LymphGland
        {
            get
            {
                return lymphGland;
            }
            set
            {
                lymphGland = value;
                RaisePropertyChanged("LymphGland");
            }
        }

        public string thyroid;
        [Required(ErrorMessage = "不能为空！")]
        public string Thyroid
        {
            get
            {
                return thyroid;
            }
            set
            {
                thyroid = value;
                RaisePropertyChanged("Thyroid");
            }
        }

        public string lungs;
        [Required(ErrorMessage = "不能为空！")]
        public string Lungs
        {
            get
            {
                return lungs;
            }
            set
            {
                lungs = value;
                RaisePropertyChanged("Lungs");
            }
        }

        public string heart;
        [Required(ErrorMessage = "不能为空！")]
        public string Heart
        {
            get
            {
                return heart;
            }
            set
            {
                heart = value;
                RaisePropertyChanged("Heart");
            }
        }

        public string abdomen;
        [Required(ErrorMessage = "不能为空！")]
        public string Abdomen
        {
            get
            {
                return abdomen;
            }
            set
            {
                abdomen = value;
                RaisePropertyChanged("Abdomen");
            }
        }

        public string liver;
        [Required(ErrorMessage = "不能为空！")]
        public string Liver
        {
            get
            {
                return liver;
            }
            set
            {
                liver = value;
                RaisePropertyChanged("Liver");
            }
        }

        public string spleen;
        [Required(ErrorMessage = "不能为空！")]
        public string Spleen
        {
            get
            {
                return spleen;
            }
            set
            {
                spleen = value;
                RaisePropertyChanged("Spleen");
            }
        }

        public string kidney;
        [Required(ErrorMessage = "不能为空！")]
        public string Kidney
        {
            get
            {
                return kidney;
            }
            set
            {
                kidney = value;
                RaisePropertyChanged("Kidney");
            }
        }

        public string diagnosisConclusion;
        [Required(ErrorMessage = "不能为空！")]
        public string DiagnosisConclusion
        {
            get
            {
                return diagnosisConclusion;
            }
            set
            {
                diagnosisConclusion = value;
                RaisePropertyChanged("DiagnosisConclusion");
            }
        }


        public string suggestion;
        public string Suggestion
        {
            get
            {
                return suggestion;
            }
            set
            {
                suggestion = value;
                RaisePropertyChanged("Suggestion");
            }
        }


        public DateTime? recordDate;
        [Required(ErrorMessage = "日期不能为空！")]
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

        public int AircrewID { get; set; }

        public int aviationMedicineID;
        [Range(1, 1000, ErrorMessage = "医师无效")]
        public int AviationMedicineID
        {
            get
            {
                return aviationMedicineID;
            }
            set
            {
                aviationMedicineID = value;
                RaisePropertyChanged("AviationMedicineID");
            }
        }
    }
}
