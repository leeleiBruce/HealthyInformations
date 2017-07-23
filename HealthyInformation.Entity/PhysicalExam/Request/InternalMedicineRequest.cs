using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.PhysicalExam.Request
{
    public class InternalMedicineRequest : BaseRequest
    {
        public string PulseStatic { get; set; }
        public string PulseSquat { get; set; }
        public string PulseRest { get; set; }
        public string BloodPressureStatic { get; set; }
        public string BloodPressureSquat { get; set; }
        public string BloodPressureRest { get; set; }
        public string MedicalHistory { get; set; }
        public string Development { get; set; }
        public string Skin { get; set; }
        public string LymphGland { get; set; }
        public string Thyroid { get; set; }
        public string Lungs { get; set; }
        public string Heart { get; set; }
        public string Abdomen { get; set; }
        public string Liver { get; set; }
        public string Spleen { get; set; }
        public string Kidney { get; set; }
        public string DiagnosisConclusion { get; set; }
        public string Suggestion { get; set; }
        public DateTime? RecordDate { get; set; }
        public int AircrewID { get; set; }
        public int AviationMedicineID { get; set; }
    }
}
