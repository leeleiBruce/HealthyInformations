using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam
{
    public class FlightDiscomfortableLevelRepository : BaseRepository<FlightDiscomfortLevel>, IFlightDiscomfortableLevelRepository
    {
        public FlightDiscomfortableLevelRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public FlightDiscomfortLevel GetFlightDiscomfortLevelByKey(int key)
        {
            return this._context.Set<FlightDiscomfortLevel>().FirstOrDefault(f => f.TransactionNumber == key);
        }

        public List<FlightDiscomfortLevel> GetFlightDiscomfortLevelByYear(int year)
        {
            return this._context.Set<FlightDiscomfortLevel>().Where(f=>f.InDate.Value.Year== year).ToList();
        }
    }
}
