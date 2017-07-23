using HealthyInformation.ClientEntity.SystemManage.Response;
using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public interface ISanatoriumManageService : IService<Sanatorium>
    {
        SanatoriumResponse GetSanatoriumList(string name, int pageIndex, int pageSize);
        BaseResponse CreateSanatorium(SanatoriumRequest request);
        BaseResponse UpdateSanatorium(SanatoriumRequest request);
        BaseResponse RemoveSanatorium(int transactionNumber);
        Sanatorium GetSanatoriumByKey(int transactionNumber);
    }
}
