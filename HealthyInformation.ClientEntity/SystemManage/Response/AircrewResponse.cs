using HealthyInformation.ClientEntity.SystemManage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Response
{
    public class AircrewResponse
    {
        public int TotalCount { get; set; }
        public List<AircrewEntity> AircrewList { get; set; }
    }
}
