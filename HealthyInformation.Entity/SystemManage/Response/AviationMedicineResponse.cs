using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Entity.SystemManage.Response
{
    public class AviationMedicineResponse
    {
        public int TotalCount { get; set; }
        public List<AviationMedicine> AviationMedicineList { get; set; }
    }
}
