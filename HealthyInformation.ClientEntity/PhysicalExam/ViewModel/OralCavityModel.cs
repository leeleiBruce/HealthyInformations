using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class OralCavityModel : ModelBase
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

        private string checkOut;
        [Required(ErrorMessage = "检查所见不能为空！")]
        public string CheckOut
        {
            get
            {
                return checkOut;
            }
            set
            {
                checkOut = value;
                RaisePropertyChanged("CheckOut");
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
    }
}
