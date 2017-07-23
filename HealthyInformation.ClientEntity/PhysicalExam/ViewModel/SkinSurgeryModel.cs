using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class SkinSurgeryModel : ModelBase
    {
        private string weight;
        [Required(ErrorMessage = "体重不能为空！")]
        public string Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                RaisePropertyChanged("Weight");
            }
        }

        private string height;
        [Required(ErrorMessage = "身高不能为空！")]
        public string Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                RaisePropertyChanged("Height");
            }
        }

        private string legLength;
        public string LegLength
        {
            get
            {
                return legLength;
            }
            set
            {
                legLength = value;
                RaisePropertyChanged("LegLength");
            }
        }

        private string sittingHeight;
        public string SittingHeight
        {
            get
            {
                return sittingHeight;
            }
            set
            {
                sittingHeight = value;
                RaisePropertyChanged("SittingHeight");
            }
        }

        private string chestMeasureCalm;
        public string ChestMeasureCalm
        {
            get
            {
                return chestMeasureCalm;
            }
            set
            {
                chestMeasureCalm = value;
                RaisePropertyChanged("ChestMeasureCalm");
            }
        }

        private string chestMeasureInhale;
        public string ChestMeasureInhale
        {
            get
            {
                return chestMeasureInhale;
            }
            set
            {
                chestMeasureInhale = value;
                RaisePropertyChanged("ChestMeasureInhale");
            }
        }

        private string chestMeasureExhalation;
        public string ChestMeasureExhalation
        {
            get
            {
                return chestMeasureExhalation;
            }
            set
            {
                chestMeasureExhalation = value;
                RaisePropertyChanged("ChestMeasureExhalation");
            }
        }

        private string vitalCapacity;
        public string VitalCapacity
        {
            get
            {
                return vitalCapacity;
            }
            set
            {
                vitalCapacity = value;
                RaisePropertyChanged("VitalCapacity");
            }
        }

        private string gripPowerLeft;
        public string GripPowerLeft
        {
            get
            {
                return gripPowerLeft;
            }
            set
            {
                gripPowerLeft = value;
                RaisePropertyChanged("GripPowerLeft");
            }
        }

        private string gripPowerRight;
        public string GripPowerRight
        {
            get
            {
                return gripPowerRight;
            }
            set
            {
                gripPowerRight = value;
                RaisePropertyChanged("GripPowerRight");
            }
        }

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

        private string examFind;
        public string ExamFind
        {
            get
            {
                return examFind;
            }
            set
            {
                examFind = value;
                RaisePropertyChanged("ExamFind");
            }
        }

        private string diagnosisConclusion;
        [Required(ErrorMessage = "诊断结论不能为空！")]
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

        private int aviationMedicineID;
        [Range(1, 1000, ErrorMessage = "医师无效！")]
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
