using HealthyInformation.Model;
using HealthyInformation.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public class FlightRecordService : BaseService<FlightRecord>, IFlightRecordService
    {
        IFlightRecordRepository flightRecordRepository;

        public FlightRecordService()
        {
            flightRecordRepository = new FlightRecordRepository(this.dbContext);
        }

        public List<FlightRecord> GetFlightRecordList(int aircrewID)
        {
            return flightRecordRepository.GetFlightRecordByAircrew(aircrewID);
        }
    }
}
