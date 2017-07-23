using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class OralCavityRepository : BaseRepository<OralCavity>, IOralCavityRepository
    {
        public OralCavityRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public OralCavity GetOralCavityByYear(int aircrewID, int year)
        {
            return this._context.Set<OralCavity>().FirstOrDefault(o => o.AircrewID == aircrewID && o.InDate.Value.Year == year);
        }

        public OralCavity GetOralCavityByKey(int transactionNumber)
        {
            return this._context.Set<OralCavity>().FirstOrDefault(o=>o.TransactionNumber== transactionNumber);
        }
    }
}
