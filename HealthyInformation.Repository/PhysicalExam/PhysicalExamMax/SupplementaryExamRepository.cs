using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class SupplementaryExamRepository : BaseRepository<SupplementaryExam>, ISupplementaryExamRepository
    {
        public SupplementaryExamRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public SupplementaryExam GetSupplementaryExamByYear(int aircrewID, int year)
        {
            return this._context.Set<SupplementaryExam>().FirstOrDefault(s => s.AircrewID == aircrewID && s.InDate.Year == year);
        }

        public SupplementaryExam GetSupplementaryExamByKey(int transactionNumber)
        {
            return this._context.Set<SupplementaryExam>().FirstOrDefault(s => s.TransactionNumber == transactionNumber);
        }
    }
}
