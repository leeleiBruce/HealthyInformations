using HealthyInformation.ClientEntity.SystemManage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Response
{
    public class CommonDiseaseResponse
    {
        public int TotalCount { get; set; }
        public List<CommonDiseaseEntity> CommonDiseaseList { get; set; }
    }
}
