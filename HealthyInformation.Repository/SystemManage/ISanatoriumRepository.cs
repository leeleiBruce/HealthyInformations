using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.SystemManage
{
    public interface ISanatoriumRepository : IRepository<Sanatorium>
    {
        IPagedList<Sanatorium> GetSanatoriumList(string name, int pageIndex, int pageSize);
        Sanatorium GetSanatoriumByKey(int transactionNumber);
    }
}
