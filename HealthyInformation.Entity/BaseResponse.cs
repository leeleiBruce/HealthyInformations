using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity
{
    public class BaseResponse
    {
        public string ResponseCode { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSucess { get; set; }
    }
}
