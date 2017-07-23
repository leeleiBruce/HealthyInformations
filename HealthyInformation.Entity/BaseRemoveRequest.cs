using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity
{
    public class BaseRemoveRequest
    {
        public List<int> KeyList { get; set; }
        public string ActionUserID { get; set; }
    }
}
