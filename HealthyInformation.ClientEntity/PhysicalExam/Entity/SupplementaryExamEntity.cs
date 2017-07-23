using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class SupplementaryExamEntity
    {
        public int TransactionNumber { get; set; }
        public string RoutineBlood { get; set; }
        public string RoutineUrine { get; set; }
        public string RoutineDefecate { get; set; }
        public string LiverFunction { get; set; }
        public string BloodSugar { get; set; }
        public string Cholesterol { get; set; }
        public string Trilaurin { get; set; }
        public string Cardiogram { get; set; }
        public string ChestXLine { get; set; }
        public string Ultrasonic { get; set; }
        public string Other { get; set; }
        public int AircrewID { get; set; }
        public System.DateTime InDate { get; set; }
        public string InUser { get; set; }
        public System.DateTime LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
