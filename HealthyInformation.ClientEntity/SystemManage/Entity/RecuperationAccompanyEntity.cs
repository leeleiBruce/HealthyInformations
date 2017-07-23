using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class RecuperationAccompanyEntity
    {
        public int TransactionNumber { get; set; }
        public int RecuperationInformationID { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
