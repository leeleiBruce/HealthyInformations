using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.SystemManage
{
    public interface IRecuperationInformationRepository : IRepository<RecuperationInformation>
    {
        List<UP_GetRecuperationPlan_Result1> GetRecuperationPlanList(int? sanatoriumID, DateTime? startDate, DateTime? endDate);
        RecuperationInformationResponse GetRecuperationInformation(int key);
        RecuperationInformation GetRecuperationPlanByKey(int key);
        RecuperationDetailResponse GetRecuperationDetail(int key);
        List<RecuperationMember> GetRecuperationMembers(int key);
        List<RecuperationAccompany> GetRecuperationAccompanies(int key);
    }
}
