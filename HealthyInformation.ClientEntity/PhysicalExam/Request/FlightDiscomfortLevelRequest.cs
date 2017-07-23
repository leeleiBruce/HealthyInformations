using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Request
{
    public class FlightDiscomfortLevelRequest : BaseRequest
    {
        public DateTime FlyDate { get; set; }
        public string FlySubject { get; set; }
        public decimal FlyHeight { get; set; }
        public int FlyerType { get; set; }
        public decimal FlySpeed { get; set; }
        public decimal FlyTotalTime { get; set; }
        public string WeatherCondition { get; set; }
        public string Complained { get; set; }
        public string Examination { get; set; }
        public string Measure { get; set; }
        public int AviationMedicineID { get; set; }
    }
}
