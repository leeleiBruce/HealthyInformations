using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class FlightDiscomfortLevelModel : ModelBase
    {
        private DateTime? flyDate;
        [Required(ErrorMessage = "飞行日期不能为空！")]
        public DateTime? FlyDate
        {
            get
            {
                return flyDate;
            }
            set
            {
                flyDate = value;
                RaisePropertyChanged("FlyDate");
            }
        }

        private string flySubject;
        [Required(ErrorMessage = "飞行科目不能为空！")]
        public string FlySubject
        {
            get
            {
                return flySubject;
            }
            set
            {
                flySubject = value;
                RaisePropertyChanged("FlySubject");
            }
        }

        private decimal? flyHeight;
        [Required(ErrorMessage = "飞行高度不能为空！")]
        public decimal? FlyHeight
        {
            get
            {
                return flyHeight;
            }
            set
            {
                flyHeight = value;
                RaisePropertyChanged("FlyHeight");
            }
        }

        private int flyerType;
        [Range(0, 1000, ErrorMessage = "机型无效！")]
        public int FlyerType
        {
            get
            {
                return flyerType;
            }
            set
            {
                flyerType = value;
                RaisePropertyChanged("FlyerType");
            }
        }

        private decimal? flySpeed;
        [Required(ErrorMessage = "飞行速度不能为空！")]
        public decimal? FlySpeed
        {
            get
            {
                return flySpeed;
            }
            set
            {
                flySpeed = value;
                RaisePropertyChanged("FlySpeed");
            }
        }

        private decimal? flyTotalTime;
        [Required(ErrorMessage = "飞行总时间不能为空！")]
        public decimal? FlyTotalTime
        {
            get
            {
                return flyTotalTime;
            }
            set
            {
                flyTotalTime = value;
                RaisePropertyChanged("FlyTotalTime");
            }
        }

        private string weatherCondition;
        [Required(ErrorMessage = "气象条件不能为空！")]
        public string WeatherCondition
        {
            get
            {
                return weatherCondition;
            }
            set
            {
                weatherCondition = value;
                RaisePropertyChanged("WeatherCondition");
            }
        }

        private string complained;
        [Required(ErrorMessage = "主诉条件不能为空！")]
        public string Complained
        {
            get
            {
                return complained;
            }
            set
            {
                complained = value;
                RaisePropertyChanged("Complained");
            }
        }

        private string examination;
        [Required(ErrorMessage = "检查不能为空！")]
        public string Examination
        {
            get
            {
                return examination;
            }
            set
            {
                examination = value;
                RaisePropertyChanged("Examination");
            }
        }

        private string measure;
        [Required(ErrorMessage = "措施不能为空！")]
        public string Measure
        {
            get
            {
                return measure;
            }
            set
            {
                measure = value;
                RaisePropertyChanged("Measure");
            }
        }

        private int aviationMedicineID;
        [Range(1, 1000, ErrorMessage = "责任医师无效！")]
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
