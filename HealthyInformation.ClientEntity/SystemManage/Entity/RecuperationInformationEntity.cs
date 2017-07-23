using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class RecuperationInformationEntity
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
}
