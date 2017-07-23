using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.FrameWork.AuthorUser
{
    public class CPApplication
    {
        public static SystemUser CurrentUser { get; set; }
    }

    public class SystemUser
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}

