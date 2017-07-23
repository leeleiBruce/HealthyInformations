using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class UP_GetRecuperationPlan_Result
    {
        public int TransactionNumber { get; set; }
        public string SanatoriumName { get; set; }
        public string LeaderName { get; set; }
        public string AviationMedicineName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}
