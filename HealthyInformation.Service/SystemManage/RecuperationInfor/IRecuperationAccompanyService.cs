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
    public interface IRecuperationAccompanyService : IService<RecuperationAccompany>
    {
        BaseResponse CreateRecuperationAccompany(RecuperationInformationRequest request);
        void RemoveRecuperationAccompany(int key);
    }
}
