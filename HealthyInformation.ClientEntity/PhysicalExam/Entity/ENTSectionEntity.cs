using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class ENTSectionEntity
    {
        public int TransactionNumber { get; set; }
        public string MedicalHistory { get; set; }
        public string CheckOut { get; set; }
        public string EarLeft { get; set; }
        public string EarRight { get; set; }
        public string EarWhisperLeft { get; set; }
        public string EarWhisperRight { get; set; }
        public string Nose { get; set; }
        public string Smell { get; set; }
        public string Ventilation { get; set; }
        public string Throat { get; set; }
        public string EarCompressor { get; set; }
        public string VestibularFunction { get; set; }
        public string DiagnosisConclusion { get; set; }
        public string Suggestion { get; set; }
        public System.DateTime RecordDate { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public string InUser { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public string LastEditUser { get; set; }
        public int AircrewID { get; set; }
        public int? AviationMedicineID { get; set; }
    }
}
