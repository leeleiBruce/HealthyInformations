using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class MedicalTreatmentEntity
    {
        public int TransactionNumber { get; set; }
        public int AircrewID { get; set; }
        public System.DateTime HospitalizationDate { get; set; }
        public System.DateTime DischargeDate { get; set; }
        public string HospitalLocation { get; set; }
        public string HospitalReason { get; set; }
        public string CheckSituation { get; set; }
        public string Diagnosis { get; set; }
        public string Conclusion { get; set; }
        public string NeedObservation { get; set; }
        public Nullable<System.DateTime> ObservationStartDate { get; set; }
        public Nullable<System.DateTime> ObservationEndDate { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
