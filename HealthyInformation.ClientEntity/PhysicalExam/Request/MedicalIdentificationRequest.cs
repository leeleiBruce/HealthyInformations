using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Request
{
    public class MedicalIdentificationRequest : BaseRequest
    {
        public int AircrewID { get; set; }

        public string Content { get; set; }

        public int AviationMedicineID { get; set; }

        public DateTime? RecordDate { get; set; }
    }
}
