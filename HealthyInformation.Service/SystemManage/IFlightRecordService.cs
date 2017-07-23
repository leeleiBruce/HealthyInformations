using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public interface IFlightRecordService : IService<FlightRecord>
    {
        List<FlightRecord> GetFlightRecordList(int aircrewID);
    }
}
