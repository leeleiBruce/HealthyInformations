using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Response
{
    public class RecuperationDetailResponse
    {
        public int TransactionNumber { get; set; }
        public int SanatoriumID { get; set; }
        public System.DateTime HospitalEnterDate { get; set; }
        public System.DateTime HospitalLeaveDate { get; set; }
        public Nullable<int> LeaderAircrewID { get; set; }
        public Nullable<int> AviationMedicineID { get; set; }

        public List<RecuperationAccompanyEntity> RecuperationAccompanyEntitys { get; set; }
        public List<RecuperationMemberEntity> RecuperationMembers { get; set; }
    }

    public class RecuperationAccompanyEntity
    {
        public int TransactionNumber { get; set; }
        public int RecuperationInformationID { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
    }

    public class RecuperationMemberEntity
    {
        public int TransactionNumber { get; set; }
        public int RecuperationInformationID { get; set; }
        public Nullable<int> AircrewID { get; set; }
    }

}
