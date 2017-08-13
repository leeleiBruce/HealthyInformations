using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.Entity
{
    public class FlightRecordEntity : ModelBase
    {
        public int AircrewID { get; set; }

        private string flightType;
        [Required(ErrorMessage = "不能为空！")]
        [Range(1,10000,ErrorMessage ="飞行机种无效！")]
        public string FlightType
        {
            get { return flightType; }
            set { flightType = value; RaisePropertyChanged(nameof(FlightType)); }
        }

        private decimal? flightTime;
        [Required(ErrorMessage = "不能为空！")]
        [Range(1, 1000000, ErrorMessage = "飞行时间超出范围，必须为1~1000000之间！")]
        public decimal? FlightTime
        {
            get
            {
                return flightTime;
            }
            set
            {
                flightTime = value;
                RaisePropertyChanged(nameof(FlightTime));
            }
        }

        private DateTime? registerDate;
        [Required(ErrorMessage = "不能为空！")]
        public System.DateTime? RegisterDate
        {
            get
            {
                return registerDate;
            }
            set
            {
                registerDate = value;
                RaisePropertyChanged("RegisterDate");
            }
        }
    }
}
