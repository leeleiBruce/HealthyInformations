using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Request
{
    public class CommonDiseaseRequest : BaseRequest
    {
        public string SymptomName { get; set; }
        public string SymptomDetail { get; set; }
        public string Medication { get; set; }
        public string TreatmentPlan { get; set; }
    }
}
