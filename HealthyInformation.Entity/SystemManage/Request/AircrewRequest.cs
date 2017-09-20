using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Request
{
    public class AircrewRequest : BaseRequest
    {
        public AircrewEntity Aircrew { get; set; }
        public List<FlightRecord> FlightRecordList { get; set; }
    }
}
