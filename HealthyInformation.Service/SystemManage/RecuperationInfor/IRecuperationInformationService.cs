using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage.RecuperationInfor
{
    public interface IRecuperationInformationService : IService<RecuperationInformation>
    {
        List<UP_GetRecuperationPlan_Result1> GetRecuperationPlanList(int? sanatoriumID, DateTime? startDate, DateTime? endDate);
        BaseResponse CreateRecuperationInformation(RecuperationInformationRequest request);
        BaseResponse UpdateRecuperationInformation(RecuperationInformationRequest request);
        RecuperationInformationResponse GetRecuperationInformation(int key);
        void RemoveRecuperationPlanByKey(int key);
        RecuperationDetailResponse GetRecuperationDetail(int key);
    }
}
