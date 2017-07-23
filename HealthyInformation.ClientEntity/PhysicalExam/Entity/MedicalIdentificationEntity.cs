using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class MedicalIdentificationEntity
    {
        public int TransactionNumber { get; set; }
        public string Content { get; set; }
        public int AviationMedicineID { get; set; }
        public System.DateTime RecordDate { get; set; }
        public System.DateTime InDate { get; set; }
        public string InUser { get; set; }
        public System.DateTime LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
