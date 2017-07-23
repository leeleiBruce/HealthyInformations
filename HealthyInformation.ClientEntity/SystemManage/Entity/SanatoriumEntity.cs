using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class SanatoriumEntity : ModelBase
    {
        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string RecommendTravelMode { get; set; }

        public string ContactPhone { get; set; }
    }
}
