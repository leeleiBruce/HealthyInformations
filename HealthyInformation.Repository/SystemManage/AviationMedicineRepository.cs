using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.SystemManage
{
    public class AviationMedicineRepository : BaseRepository<AviationMedicine>, IAviationMedicineRepository
    {
        public AviationMedicineRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public IPagedList<AviationMedicine> GetAviationMedicineList(string name, int pageIndex, int pageSize)
        {
            IQueryable<AviationMedicine> query = this._context.Set<AviationMedicine>();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(q => q.Name.Contains(name));
            }

            query = query.OrderByDescending(q => q.TransactionNumber);
            return new PagedList<AviationMedicine>(query, pageIndex, pageSize);
        }

        public AviationMedicine GetAviationMedicineByKey(int transactionNumber)
        {
            return this._context.Set<AviationMedicine>().SingleOrDefault(a => a.TransactionNumber == transactionNumber);
        }
    }
}
