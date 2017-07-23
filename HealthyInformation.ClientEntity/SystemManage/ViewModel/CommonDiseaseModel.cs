using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.ViewModel
{
    public class CommonDiseaseModel : ModelBase
    {
        private string symptomName;
        [Required(ErrorMessage = "常见病名称不能为空！")]
        public string SymptomName
        {
            get
            {
                return symptomName;
            }
            set
            {
                symptomName = value;
                RaisePropertyChanged("SymptomName");
            }
        }

        private string symptomDetail;
        [Required(ErrorMessage = "症状不能为空！")]
        public string SymptomDetail
        {
            get
            {
                return symptomDetail;
            }
            set
            {
                symptomDetail = value;
                RaisePropertyChanged("SymptomDetail");
            }
        }

        private string medication;
        [Required(ErrorMessage = "用药不能为空！")]
        public string Medication
        {
            get
            {
                return medication;
            }
            set
            {
                medication = value;
                RaisePropertyChanged("Medication");
            }
        }

        private string treatmentPlan;
        [Required(ErrorMessage = "治疗方案不能为空！")]
        public string TreatmentPlan
        {
            get
            {
                return treatmentPlan;
            }
            set
            {
                treatmentPlan = value;
                RaisePropertyChanged("TreatmentPlan");
            }
        }
    }
}
