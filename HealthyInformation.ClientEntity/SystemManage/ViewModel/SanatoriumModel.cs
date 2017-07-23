using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.ViewModel
{
    public class SanatoriumModel : ModelBase
    {
        private string name;
        [Required(ErrorMessage = "疗养院名称不能为空！")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string address;
        [Required(ErrorMessage = "详细地址不能为空！", AllowEmptyStrings = false)]
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        private string recommendTravelMode;
        [Required(ErrorMessage = "建议出行方式不能为空！", AllowEmptyStrings = false)]
        public string RecommendTravelMode
        {
            get
            {
                return recommendTravelMode;
            }
            set
            {
                recommendTravelMode = value;
                RaisePropertyChanged("RecommendTravelMode");
            }
        }

        private string contactPhone;
         [Required(ErrorMessage = "联系电话不能为空！", AllowEmptyStrings = false)]
        public string ContactPhone
        {
            get
            {
                return contactPhone;
            }
            set
            {
                contactPhone = value;
                RaisePropertyChanged("ContactPhone");
            }
        }
    }
}
