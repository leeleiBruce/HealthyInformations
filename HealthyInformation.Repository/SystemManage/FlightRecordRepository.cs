using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.SystemManage
{
    public class FlightRecordRepository : BaseRepository<FlightRecord>, IFlightRecordRepository
    {
        public FlightRecordRepository(DbContext dbContext)
            : base(dbContext)
        { }

        public List<FlightRecord> GetFlightRecordByAircrew(int aircrewID)
        {
            IQueryable<FlightRecord> query = this._context.Set<FlightRecord>();
            query = query.Where(q => q.AircrewID == aircrewID);

            return query.ToList();
        }
    }
}
