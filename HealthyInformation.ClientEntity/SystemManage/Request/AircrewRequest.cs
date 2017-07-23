using HealthyInformation.ClientEntity.SystemManage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Request
{
    public class AircrewRequest : BaseRequest
    {
        public AircrewEntity Aircrew { get; set; }
        public List<FlightRecordEntity> FlightRecordList { get; set; }
    }
}
