using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class ConclusionPhysicalRepository : BaseRepository<ConclusionsPhysicalExam>, IConclusionPhysicalRepository
    {
        public ConclusionPhysicalRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public ConclusionsPhysicalExam GetConclusionsPhysicalExamByYear(int aircrewID, int year)
        {
            return this._context.Set<ConclusionsPhysicalExam>().FirstOrDefault(c => c.AircrewID == aircrewID && c.InDate.Year == year);
        }

        public ConclusionsPhysicalExam GetConclusionsPhysicalExamByKey(int transactionNumber)
        {
            return this._context.Set<ConclusionsPhysicalExam>().FirstOrDefault(c => c.TransactionNumber == transactionNumber);
        }
    }
}
