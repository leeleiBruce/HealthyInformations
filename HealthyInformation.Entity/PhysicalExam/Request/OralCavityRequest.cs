using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.PhysicalExam.Request
{
    public class OralCavityRequest : BaseRequest
    {
        public string MedicalHistory { get; set; }
        public string CheckOut { get; set; }
        public string Diagnosis { get; set; }
        public string Conclusion { get; set; }
        public string Suggestion { get; set; }
        public int AircrewID { get; set; }
    }
}
