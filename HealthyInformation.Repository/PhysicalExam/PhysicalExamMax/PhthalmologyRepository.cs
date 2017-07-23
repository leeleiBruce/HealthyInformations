using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class PhthalmologyRepository : BaseRepository<Phthalmology>, IPhthalmologyRepository
    {
        public PhthalmologyRepository(DbContext dbContext)
            : base(dbContext)
        { }

        public Phthalmology GetPhthalmologyByYear(int aircrewID, int year)
        {
            return this._context.Set<Phthalmology>().FirstOrDefault(p => p.AircrewID == aircrewID && p.InDate.Value.Year == year);
        }

        public Phthalmology GetPhthalmologyByKey(int transactionNumber)
        {
            return this._context.Set<Phthalmology>().FirstOrDefault(p => p.TransactionNumber == transactionNumber);
        }
    }
}
