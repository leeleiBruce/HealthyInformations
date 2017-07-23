using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.PhysicalExam.Request
{
    public class ConclusionPhysicalRequest : BaseRequest
    {
        public string Diagnosis { get; set; }
        public string Conclusion { get; set; }
        public int HealthyGrade { get; set; }
        public string Suggestion { get; set; }
        public string DiseaseKeyword { get; set; }
        public string CollegeCenter { get; set; }
        public string CertifyingCommission { get; set; }
        public string Director { get; set; }
        public int AircrewID { get; set; }
    }
}
