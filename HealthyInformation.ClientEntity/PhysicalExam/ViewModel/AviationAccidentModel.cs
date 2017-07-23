using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class AviationAccidentModel : ModelBase
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

        private string condition;
        [Required(ErrorMessage = "发生情况不能为空！")]
        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                RaisePropertyChanged("Condition");
            }
        }

        private string reason;
        [Required(ErrorMessage = "原因分析不能为空！")]
        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
                reason = value;
                RaisePropertyChanged("Reason");
            }
        }

        private string nature;
        public string Nature
        {
            get
            {
                return nature;
            }
            set
            {
                nature = value;
                RaisePropertyChanged("Nature");
            }
        }

        private string suggestion;
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

        private int avationMedicineID;
        [Range(0, 1000, ErrorMessage = "责任医师不合法！")]
        public int AvationMedicineID
        {
            get
            {
                return avationMedicineID;
            }
            set
            {
                avationMedicineID = value;
                RaisePropertyChanged("AvationMedicineID");
            }
        }
    }
}
