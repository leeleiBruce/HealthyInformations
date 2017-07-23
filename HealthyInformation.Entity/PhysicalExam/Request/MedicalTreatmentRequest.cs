using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.PhysicalExam.Request
{
    public class MedicalTreatmentRequest : BaseRequest
    {
        public int AircrewID { get; set; }
        public DateTime HospitalizationDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public string HospitalLocation { get; set; }
        public string HospitalReason { get; set; }
        public string CheckSituation { get; set; }
        public string Diagnosis { get; set; }
        public string Conclusion { get; set; }
        public string NeedObservation { get; set; }
        public Nullable<System.DateTime> ObservationStartDate { get; set; }
        public Nullable<System.DateTime> ObservationEndDate { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
