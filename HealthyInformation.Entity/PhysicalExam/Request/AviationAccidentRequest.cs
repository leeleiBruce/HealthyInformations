using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.PhysicalExam.Request
{
    public class AviationAccidentRequest : BaseRequest
    {
        public DateTime? FlyDate { get; set; }
        public string FlySubject { get; set; }
        public string Condition { get; set; }
        public string Reason { get; set; }
        public string Nature { get; set; }
        public string Suggestion { get; set; }
        public int AvationMedicineID { get; set; }
    }
}
