using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class UP_GetMedicalTreatAlarmInfo_Result
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string JobTitle { get; set; }
        public string TroopsType { get; set; }
        public Nullable<System.DateTime> ObservationEndDate { get; set; }
        public Nullable<System.DateTime> ObservationStartDate { get; set; }
        public string HospitalLocation { get; set; }
    }
}
