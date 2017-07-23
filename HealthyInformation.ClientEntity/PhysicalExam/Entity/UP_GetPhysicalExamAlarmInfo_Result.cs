using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class UP_GetPhysicalExamAlarmInfo_Result
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string TroopsTel { get; set; }
        public string TroopsType { get; set; }
        public string Sex { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
