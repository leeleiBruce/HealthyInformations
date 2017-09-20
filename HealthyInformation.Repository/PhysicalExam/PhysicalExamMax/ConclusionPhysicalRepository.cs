using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class ConclusionPhysicalRepository : BaseRepository<ConclusionsPhysical>, IConclusionPhysicalRepository
    {
        public ConclusionPhysicalRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public ConclusionsPhysical GetConclusionsPhysicalExamByYear(int aircrewID, int year)
        {
            return this._context.Set<ConclusionsPhysical>().FirstOrDefault(c => c.AircrewID == aircrewID && c.InDate.Year == year);
        }

        public ConclusionsPhysical GetConclusionsPhysicalExamByKey(int transactionNumber)
        {
            return this._context.Set<ConclusionsPhysical>().FirstOrDefault(c => c.TransactionNumber == transactionNumber);
        }
    }
}
