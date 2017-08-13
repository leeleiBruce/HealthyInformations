using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.LoginManage
{
    public interface IUserService : IService<User>
    {
        User GetUser(string userName);

        void UpdateUserPassWord(UserPwdUpdateRequest request);
    }
}
