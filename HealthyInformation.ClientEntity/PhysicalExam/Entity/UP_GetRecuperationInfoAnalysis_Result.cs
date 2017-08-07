using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Entity
{
    public class UP_GetRecuperationInfoAnalysis_Result
    {
        public System.DateTime HospitalEnterDate { get; set; }
        public System.DateTime HospitalLeaveDate { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string TroopsType { get; set; }
        public string JobTitle { get; set; }
        public string SanatoriumName { get; set; }
    }
}
