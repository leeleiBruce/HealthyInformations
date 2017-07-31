using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam
{
    public class AviationAccidentRepository : BaseRepository<AviationAccident>, IAviationAccidentRepository
    {
        public AviationAccidentRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public AviationAccident GetAviationAccidentByKey(int key)
        {
            return this._context.Set<AviationAccident>().FirstOrDefault(f => f.TransactionNumber == key);
        }

        public List<AviationAccident> GetAviationAccidentByYear(int year)
        {
            return this._context.Set<AviationAccident>().Where(f => f.InDate.Value.Year == year).ToList();
        }
    }
}
