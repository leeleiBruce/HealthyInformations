using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Request
{
    public class FlightRecordRequest : BaseRequest
    {
        public int AircrewID { get; set; }
        public string FlightType { get; set; }
        public decimal FlightTime { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
