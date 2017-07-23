using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Request
{
    public class SkinSurgeryRequest : BaseRequest
    {
        public string Weight { get; set; }
        public string Height { get; set; }
        public string LegLength { get; set; }
        public string SittingHeight { get; set; }
        public string ChestMeasureCalm { get; set; }
        public string ChestMeasureInhale { get; set; }
        public string ChestMeasureExhalation { get; set; }
        public string VitalCapacity { get; set; }
        public string GripPowerLeft { get; set; }
        public string GripPowerRight { get; set; }
        public string MedicalHistory { get; set; }
        public string ExamFind { get; set; }
        public string DiagnosisConclusion { get; set; }
        public int AviationMedicineID { get; set; }
        public int AircrewID { get; set; }
        public DateTime? RecordDate { get; set; }
    }
}
