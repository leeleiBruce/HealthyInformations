﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class FlyerTypeEntity: BaseRequest
    {
        public string TypeName { get; set; }
        public DateTime? InDate { get; set; }
    }
}
