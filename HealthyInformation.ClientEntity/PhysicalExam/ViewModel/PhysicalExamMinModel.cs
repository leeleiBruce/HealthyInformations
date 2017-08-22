using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class PhysicalExamMinModel : ModelBase
    {
        private decimal? weight;
        [Required(ErrorMessage = "体重必须为整数或小数且不能为空！")]
        public decimal? Weight
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

        private int? pulse;
        [Required(ErrorMessage = "脉搏必须为整数且不能为空！")]
        public int? Pulse
        {
            get
            {
                return pulse;
            }
            set
            {
                pulse = value;
                RaisePropertyChanged("Pulse");
            }
        }

        private int? bloodPressure;
        [Required(ErrorMessage = "血压必须为整数且不能为空！")]
        public int? BloodPressure
        {
            get
            {
                return bloodPressure;
            }
            set
            {
                bloodPressure = value;
                RaisePropertyChanged("BloodPressure");
            }
        }

        private decimal? visionLeft;
        [Required(ErrorMessage = "左眼视力必须为整数或小数且不能为空！")]
        public decimal? VisionLeft
        {
            get
            {
                return visionLeft;
            }
            set
            {
                visionLeft = value;
                RaisePropertyChanged("VisionLeft");
            }
        }

        private decimal? visionRight;
        [Required(ErrorMessage = "右眼视力必须为整数或小数且不能为空！")]
        public decimal? VisionRight
        {
            get
            {
                return visionRight;
            }
            set
            {
                visionRight = value;
                RaisePropertyChanged("VisionRight");
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

        private int? aviationMedicineID;
        [Required(ErrorMessage = "医师不能为空！")]
        [Range(1, 1000, ErrorMessage = "所选医师无效！")]
        public int? AviationMedicineID
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
