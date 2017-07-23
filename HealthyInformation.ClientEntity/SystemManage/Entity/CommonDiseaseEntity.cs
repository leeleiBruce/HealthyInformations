using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class CommonDiseaseEntity : ModelBase
    {
        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        public string SymptomName { get; set; }
        public string SymptomDetail { get; set; }
        public string Medication { get; set; }
        public string TreatmentPlan { get; set; }
    }
}
