using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class ENTSectionRepository : BaseRepository<ENTSection>, IENTSectionRepository
    {
        public ENTSectionRepository(DbContext dbContext)
            : base(dbContext) { }

        public ENTSection GetENTSectionByYear(int aircrewID, int year)
        {
            return this._context.Set<ENTSection>().AsNoTracking().FirstOrDefault(e => e.AircrewID == aircrewID && e.RecordDate.Year == year);
        }

        public ENTSection GetENTSectionByKey(int transactionNumber)
        {
            return _context.Set<ENTSection>().FirstOrDefault(e => e.TransactionNumber == transactionNumber);
        }
    }
}
