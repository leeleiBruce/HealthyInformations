using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.SystemManage
{
    public interface IFlightRecordRepository : IRepository<FlightRecord>
    {
        List<FlightRecord> GetFlightRecordByAircrew(int aircrewID);
    }
}
