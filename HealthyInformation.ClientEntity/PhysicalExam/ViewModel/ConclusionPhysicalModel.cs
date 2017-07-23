using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class ConclusionPhysicalModel : ModelBase
    {
        private string diagnosis;
        [Required(ErrorMessage = "不能为空！")]
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
        [Required(ErrorMessage = "不能为空！")]
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

        private int healthyGrade;
        [Range(1, 10, ErrorMessage = "健康等级无效！")]
        public int HealthyGrade
        {
            get
            {
                return healthyGrade;
            }
            set
            {
                healthyGrade = value;
                RaisePropertyChanged("HealthyGrade");
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

        private string diseaseKeyword;
        public string DiseaseKeyword
        {
            get
            {
                return diseaseKeyword;
            }
            set
            {
                diseaseKeyword = value;
                RaisePropertyChanged("DiseaseKeyword");
            }
        }

        private string collegeCenter;
        public string CollegeCenter
        {
            get
            {
                return collegeCenter;
            }
            set
            {
                collegeCenter = value;
                RaisePropertyChanged("CollegeCenter");
            }
        }

        private string certifyingCommission;
        public string CertifyingCommission
        {
            get
            {
                return certifyingCommission;
            }
            set
            {
                certifyingCommission = value;
                RaisePropertyChanged("CertifyingCommission");
            }
        }

        private string director;
        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
                RaisePropertyChanged("Director");
            }
        }
    }
}
