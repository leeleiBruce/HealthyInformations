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
    public class DiseaseRepository : BaseRepository<CommonDisease>, IDiseaseRepository
    {
        public DiseaseRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public PagedList<CommonDisease> GetCommonDisease(string name, int pageIndex, int pageSize)
        {
            IQueryable<CommonDisease> query = this._context.Set<CommonDisease>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(q => q.SymptomName.Contains(name));
            }

            query = query.OrderByDescending(q => q.TransactionNumber);
            return new PagedList<CommonDisease>(query, pageIndex, pageSize);
        }

        public bool IsCommonDiseaseExists(string symptomName)
        {
            IQueryable<CommonDisease> query = this._context.Set<CommonDisease>();
            return query.Any(q => q.SymptomName.Equals(symptomName, StringComparison.CurrentCultureIgnoreCase));
        }

        public CommonDisease GetCommonDiseaseByKey(int transactionNumber)
        {
            IQueryable<CommonDisease> query = this._context.Set<CommonDisease>();
            return query.SingleOrDefault(q => q.TransactionNumber == transactionNumber);
        }
    }
}
