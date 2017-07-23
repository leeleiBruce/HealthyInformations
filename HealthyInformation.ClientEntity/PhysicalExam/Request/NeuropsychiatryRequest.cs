using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Request
{
    public class NeuropsychiatryRequest : BaseRequest
    {
        public string MedicalHistory { get; set; }
        public string Psychosis { get; set; }
        public string CranialNerve { get; set; }
        public string MovementsOfLimbs { get; set; }
        public string Quiescent { get; set; }
        public string TendonReflex { get; set; }
        public string NerveEnding { get; set; }
        public string VegetativeNerve { get; set; }
        public string DiagnosisConclusion { get; set; }
        public string Suggestion { get; set; }
        public int AviationMedicineID { get; set; }
        public int AircrewID { get; set; }
        public DateTime? RecordDate { get; set; }
    }
}
