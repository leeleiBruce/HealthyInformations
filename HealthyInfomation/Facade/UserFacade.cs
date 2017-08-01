using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInfomation.Facade
{
    public class UserFacade : RestClientWrapper
    {
        public UserFacade(WindowBase windowBase)
            : base("UsersService", "SystemManage", windowBase)
        {
        }

        public async Task<UserEntity> GetUser(string userName)
        {
            return await this.GetAsync<UserEntity>(string.Format("get?userName={0}", Uri.EscapeDataString(userName)));
        }

        public async Task UpdateUserPwd(UserPwdUpdateRequest request)
        {
            await this.PutAsync<UserPwdUpdateRequest, string>("update/pwd", request);
        }
    }
}
