using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Request
{
    public class SanatoriumRequest : BaseRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string RecommendTravelMode { get; set; }

        public string ContactPhone { get; set; }
    }
}
