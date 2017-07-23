using HealthyInformation.ClientEntity.SystemManage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Request
{
    public class RecuperationInformationRequest : BaseRequest
    {
        public int SanatoriumID { get; set; }
        public DateTime HospitalEnterDate { get; set; }
        public DateTime HospitalLeaveDate { get; set; }
        public int? LeaderAircrewID { get; set; }
        public int? AviationMedicineID { get; set; }

        public List<RecuperationMemberEntity> RecuperationMemberList { get; set; }
        public List<RecuperationAccompanyEntity> RecuperationAccompanyList { get; set; }
    }
}
