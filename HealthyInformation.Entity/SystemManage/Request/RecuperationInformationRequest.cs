using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Request
{
    public class RecuperationInformationRequest : BaseRequest
    {
        public int SanatoriumID { get; set; }
        public DateTime HospitalEnterDate { get; set; }
        public DateTime HospitalLeaveDate { get; set; }
        public int? LeaderAircrewID { get; set; }
        public int? AviationMedicineID { get; set; }

        public List<RecuperationMember> RecuperationMemberList { get; set; }
        public List<RecuperationAccompany> RecuperationAccompanyList { get; set; }
    }
}
