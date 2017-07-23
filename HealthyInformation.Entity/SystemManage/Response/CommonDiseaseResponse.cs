﻿using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Response
{
    public class CommonDiseaseResponse
    {
        public int TotalCount { get; set; }
        public List<CommonDisease> CommonDiseaseList { get; set; }
    }
}
