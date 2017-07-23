using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
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
    public class SanatoriumRepository : BaseRepository<Sanatorium>, ISanatoriumRepository
    {
        public SanatoriumRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IPagedList<Sanatorium> GetSanatoriumList(string name, int pageIndex, int pageSize)
        {
            IQueryable<Sanatorium> query = this._context.Set<Sanatorium>();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(q => q.Name.Contains(name));
            }

            query = query.OrderByDescending(q => q.TransactionNumber);

            return new PagedList<Sanatorium>(query, pageIndex, pageSize);
        }

        public Sanatorium GetSanatoriumByKey(int transactionNumber)
        {
            return this._context.Set<Sanatorium>().FirstOrDefault(s => s.TransactionNumber == transactionNumber);
        }
    }
}
