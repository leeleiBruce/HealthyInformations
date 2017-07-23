using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class SupplementaryExamModel : ModelBase
    {
        private string routineBlood;
        [Required(ErrorMessage ="血常规不能为空！")]
        public string RoutineBlood
        {
            get
            {
                return routineBlood;
            }
            set
            {
                routineBlood = value;
                RaisePropertyChanged("RoutineBlood");
            }
        }

        private string routineUrine;
        [Required(ErrorMessage = "尿常规不能为空！")]
        public string RoutineUrine
        {
            get
            {
                return routineUrine;
            }
            set
            {
                routineUrine = value;
                RaisePropertyChanged("RoutineUrine");
            }
        }

        private string routineDefecate;
        [Required(ErrorMessage = "便常规不能为空！")]
        public string RoutineDefecate
        {
            get
            {
                return routineDefecate;
            }
            set
            {
                routineDefecate = value;
                RaisePropertyChanged("RoutineDefecate");
            }
        }

        private string liverFunction;
        [Required(ErrorMessage = "肝功能不能为空！")]
        public string LiverFunction
        {
            get
            {
                return liverFunction;
            }
            set
            {
                liverFunction = value;
                RaisePropertyChanged("LiverFunction");
            }
        }

        private string bloodSugar;
        public string BloodSugar
        {
            get
            {
                return bloodSugar;
            }
            set
            {
                bloodSugar = value;
                RaisePropertyChanged("BloodSugar");
            }
        }

        private string cholesterol;
        public string Cholesterol
        {
            get
            {
                return cholesterol;
            }
            set
            {
                cholesterol = value;
                RaisePropertyChanged("Cholesterol");
            }
        }

        private string trilaurin;
        public string Trilaurin
        {
            get
            {
                return trilaurin;
            }
            set
            {
                trilaurin = value;
                RaisePropertyChanged("Trilaurin");
            }
        }

        private string cardiogram;
        [Required(ErrorMessage = "心电图不能为空！")]
        public string Cardiogram
        {
            get
            {
                return cardiogram;
            }
            set
            {
                cardiogram = value;
                RaisePropertyChanged("Cardiogram");
            }
        }

        private string chestXLine;
        public string ChestXLine
        {
            get
            {
                return chestXLine;
            }
            set
            {
                chestXLine = value;
                RaisePropertyChanged("ChestXLine");
            }
        }

        private string ultrasonic;
        public string Ultrasonic
        {
            get
            {
                return ultrasonic;
            }
            set
            {
                ultrasonic = value;
                RaisePropertyChanged("Ultrasonic");
            }
        }

        private string other;
        public string Other
        {
            get
            {
                return other;
            }
            set
            {
                other = value;
                RaisePropertyChanged("Other");
            }
        }

        private int aircrewID;
        public int AircrewID
        {
            get
            {
               return aircrewID;
            }
            set
            {
                aircrewID = value;
                RaisePropertyChanged("AircrewID");
            }
        }
    }
}
