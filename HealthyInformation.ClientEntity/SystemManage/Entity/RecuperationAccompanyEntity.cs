using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class RecuperationAccompanyEntity : ModelBase
    {
        public int RecuperationInformationID { get; set; }

        [Required(ErrorMessage ="姓名不能为空！")]
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
