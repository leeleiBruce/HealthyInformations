using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Request
{
    public class UserPwdUpdateRequest
    {
        public string UserName { get; set; }

        public string NewPassWord { get; set; }
    }
}
