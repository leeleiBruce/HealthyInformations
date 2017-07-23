using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Response
{
    [DataContract]
    public class RecuperationInformationResponse
    {
        [DataMember]
        public int TransactionNumber { get; set; }
        [DataMember]
        public string SanatoriumName { get; set; }
        [DataMember]
        public string SanatoriumAddress { get; set; }
        [DataMember]
        public string RecommendTravelMode { get; set; }
        [DataMember]
        public string LeaderAircrew { get; set; }
        [DataMember]
        public string LeaderContactTel { get; set; }
        [DataMember]
        public string AviationMedicineName { get; set; }
        [DataMember]
        public string AviationMedicineTel { get; set; }
        [DataMember]
        public List<RecuperationMemberSimple> RecuperationAccompanyList { get; set; }
        [DataMember]
        public List<RecuperationMemberSimple> RecuperationMemberList { get; set; }
    }
    [DataContract]
    public class RecuperationMemberSimple
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
