using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class NeuropsychiatryModel : ModelBase
    {
        private string medicalHistory;
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

        private string psychosis;
        [Required(ErrorMessage = "不能为空！")]
        public string Psychosis
        {
            get
            {
                return psychosis;
            }
            set
            {
                psychosis = value;
                RaisePropertyChanged("Psychosis");
            }
        }

        private string cranialNerve;
        [Required(ErrorMessage = "不能为空！")]
        public string CranialNerve
        {
            get
            {
                return cranialNerve;
            }
            set
            {
                cranialNerve = value;
                RaisePropertyChanged("CranialNerve");
            }
        }

        private string movementsOfLimbs;
        [Required(ErrorMessage = "不能为空！")]
        public string MovementsOfLimbs
        {
            get
            {
                return movementsOfLimbs;
            }
            set
            {
                movementsOfLimbs = value;
                RaisePropertyChanged("MovementsOfLimbs");
            }
        }

        private string quiescent;
        [Required(ErrorMessage = "不能为空！")]
        public string Quiescent
        {
            get
            {
                return quiescent;
            }
            set
            {
                quiescent = value;
                RaisePropertyChanged("Quiescent");
            }
        }

        private string tendonReflex;
        [Required(ErrorMessage = "不能为空！")]
        public string TendonReflex
        {
            get
            {
                return tendonReflex;
            }
            set
            {
                tendonReflex = value;
                RaisePropertyChanged("TendonReflex");
            }
        }

        private string nerveEnding;
        [Required(ErrorMessage = "不能为空！")]
        public string NerveEnding
        {
            get
            {
                return nerveEnding;
            }
            set
            {
                nerveEnding = value;
                RaisePropertyChanged("NerveEnding");
            }
        }

        private string vegetativeNerve;
        [Required(ErrorMessage = "不能为空！")]
        public string VegetativeNerve
        {
            get
            {
                return vegetativeNerve;
            }
            set
            {
                vegetativeNerve = value;
                RaisePropertyChanged("VegetativeNerve");
            }
        }

        private string diagnosisConclusion;
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

        private string suggestion;
        [Required(ErrorMessage = "不能为空！")]
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

        public int AircrewID { get; set; }

        private int aviationMedicineID;
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

        private DateTime? recordDate;
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
    }
}
