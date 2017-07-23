using System;

namespace HealthyInformation.Entity.PhysicalExam
{
    public class PhysicalExamMinRecordRequest : BaseRequest
    {
        public int AircrewID { get; set; }
        public decimal Weight { get; set; }
        public int Pulse { get; set; }
        public decimal BloodPressure { get; set; }
        public decimal VisionLeft { get; set; }
        public decimal VisionRight { get; set; }
        public string Conclusion { get; set; }
        public int AviationMedicineID { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
