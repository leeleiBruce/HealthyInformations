using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class ConclusionsphysicalexamEntity
    {
        public int TransactionNumber { get; set; }
        public string Diagnosis { get; set; }
        public string Conclusion { get; set; }
        public int HealthyGrade { get; set; }
        public string Suggestion { get; set; }
        public string DiseaseKeyword { get; set; }
        public string CollegeCenter { get; set; }
        public string CertifyingCommission { get; set; }
        public string Director { get; set; }
        public int AircrewID { get; set; }
        public System.DateTime InDate { get; set; }
        public string InUser { get; set; }
        public System.DateTime LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
