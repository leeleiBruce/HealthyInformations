using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Request
{
    public class AircrewEntity
    {
        public int TransactionNumber { get; set; }
        public string Name { get; set; }
        public System.DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public string Nation { get; set; }
        public string Photo { get; set; }
        public string Degree { get; set; }
        public System.DateTime EnlistmentTime { get; set; }
        public System.DateTime PartyTime { get; set; }
        public string NativePlace { get; set; }
        public string TroopsType { get; set; }
        public string TroopsTel { get; set; }
        public string JobTitle { get; set; }
        public string MilitaryRank { get; set; }
        public System.DateTime GraduationJuniorDate { get; set; }
        public System.DateTime GraduationDate { get; set; }
        public System.DateTime PilotPlaneDate { get; set; }
        public string TerminateContractDetail { get; set; }
        public System.DateTime InDate { get; set; }
        public string InUser { get; set; }
        public System.DateTime LastEditDate { get; set; }
        public string LastEditUser { get; set; }
        public string AdmissionJuniorCollege { get; set; }
        public string AdmissionCollege { get; set; }
    }
}
