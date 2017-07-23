using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Request
{
    public class AviationMedicineRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string GraduationSchool { get; set; }
        public string Professional { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string ContactPhone { get; set; }
        public string Qualifications { get; set; }
    }
}
