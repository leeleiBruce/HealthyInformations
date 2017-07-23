using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class OralCavityEntity
    {
        public int TransactionNumber { get; set; }
        public string MedicalHistory { get; set; }
        public string CheckOut { get; set; }
        public string Diagnosis { get; set; }
        public string Conclusion { get; set; }
        public string Suggestion { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public string InUser { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public string LastEditUser { get; set; }
        public int AircrewID { get; set; }
    }
}
