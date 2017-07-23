using HealthyInformation.Service;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;

namespace HealthyInformation.Service.SystemManage
{
    public interface IDiseaseService : IService<CommonDisease>
    {
        CommonDiseaseResponse GetCommonDisease(string name, int pageIndex, int pageSize);
        BaseResponse CreateCommonDisease(CommonDiseaseRequest request);
        BaseResponse UpdateCommonDisease(CommonDiseaseRequest request);
        BaseResponse RemoveCommonDisease(int transactionNumber);
    }
}
