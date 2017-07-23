using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage.RecuperationInfor
{
    public interface IRecuperationInformationMemberService : IService<RecuperationMember>
    {
        BaseResponse CreateRecuperationMember(RecuperationInformationRequest request);
        void RemoveRecuperationMember(int key);
    }
}
