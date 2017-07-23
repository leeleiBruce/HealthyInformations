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
    public interface IDiseaseRepository : IRepository<CommonDisease>
    {
        PagedList<CommonDisease> GetCommonDisease(string name, int pageIndex, int pageSize);
        bool IsCommonDiseaseExists(string symptomName);
        CommonDisease GetCommonDiseaseByKey(int transactionNumber);
    }
}
