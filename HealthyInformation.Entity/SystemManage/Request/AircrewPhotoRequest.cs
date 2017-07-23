using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Request
{
    public class AircrewPhotoRequest: BaseRequest
    {
        [DataMember]
        public string PhotoBinary { get; set; }
    }
}
