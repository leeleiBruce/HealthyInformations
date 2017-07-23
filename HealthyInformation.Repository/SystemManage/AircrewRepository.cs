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
    public class AircrewRepository : BaseRepository<Aircrew>, IAircrewRepository
    {
        public AircrewRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IPagedList<Aircrew> GetAircrewList(string name, DateTime? startDate, DateTime? endDate, int pageIndex, int pageSize)
        {
            IQueryable<Aircrew> query = this._context.Set<Aircrew>();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(q => q.Name.Contains(name));
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(q => q.InDate >= startDate && q.InDate <= endDate);
            }

            query = query.OrderByDescending(q => q.TransactionNumber);

            return new PagedList<Aircrew>(query, pageIndex, pageSize);
        }

        public Aircrew GetAircrewByKey(int transactionNumber)
        {
            return _context.Set<Aircrew>().FirstOrDefault(a => a.TransactionNumber == transactionNumber);
        }
    }
}
