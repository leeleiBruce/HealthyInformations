using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class FlightRecordEntity
    {
        public int TransactionNumber { get; set; }
        public int AircrewID { get; set; }
        public string FlightType { get; set; }
        public decimal FlightTime { get; set; }
        public System.DateTime? RegisterDate { get; set; }
    }
}
