using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Response
{
    public class RecuperationInformationResponse
    {
        public int TransactionNumber { get; set; }
        public string SanatoriumName { get; set; }
        public string SanatoriumAddress { get; set; }
        public string RecommendTravelMode { get; set; }
        public string LeaderAircrew { get; set; }
        public string LeaderContactTel { get; set; }
        public string AviationMedicineName { get; set; }
        public string AviationMedicineTel { get; set; }

        public List<RecuperationMember> RecuperationAccompanyList { get; set; }

        public List<RecuperationMember> RecuperationMemberList { get; set; }
    }

    public class RecuperationMember
    {
        public string SanatoriumName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NameRepeat { get; set; }
        public string PhoneNumberRepeat { get; set; }
    }
}
