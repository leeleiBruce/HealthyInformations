using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class NeuropsychiatryRepository : BaseRepository<Neuropsychiatry>, INeuropsychiatryRepository
    {
        public NeuropsychiatryRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public Neuropsychiatry GetNeuropsychiatryByYear(int aircrewID, int year)
        {
            return this._context.Set<Neuropsychiatry>().FirstOrDefault(n => n.AircrewID == aircrewID && n.RecordDate.Year == year);
        }

        public Neuropsychiatry GetNeuropsychiatryByKey(int transactionNumber)
        {
            return this._context.Set<Neuropsychiatry>().FirstOrDefault(n => n.TransactionNumber == transactionNumber);
        }
    }
}
