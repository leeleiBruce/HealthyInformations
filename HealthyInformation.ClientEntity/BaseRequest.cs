using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity
{
    public class BaseRequest
    {
        public int TransactionNumber { get; set; }
        public string ActionUserID { get; set; }
    }
}
