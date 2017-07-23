using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class AircrewEntity : ModelBase
    {
        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public string Nation { get; set; }
        public string Photo { get; set; }
        public string Degree { get; set; }
        public DateTime EnlistmentTime { get; set; }
        public DateTime PartyTime { get; set; }
        public string NativePlace { get; set; }
        public string TroopsType { get; set; }
        public string TroopsTel { get; set; }
        public string JobTitle { get; set; }
        public string MilitaryRank { get; set; }
        public string AdmissionJuniorCollege { get; set; }
        public DateTime GraduationJuniorDate { get; set; }
        public string AdmissionCollege { get; set; }
        public DateTime GraduationDate { get; set; }
        public DateTime PilotPlaneDate { get; set; }
        public string TerminateContractDetail { get; set; }
        public DateTime InDate { get; set; }
        public string InUser { get; set; }
        public DateTime LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
