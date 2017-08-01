using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUsersService”。
    [ServiceContract]
    public interface IUsersService
    {
        [OperationContract]
        [WebGet(UriTemplate = "get?userName={userName}", ResponseFormat = WebMessageFormat.Json)]
        User GetUser(string userName);

        [OperationContract]
        [WebInvoke(UriTemplate = "update/pwd", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateUserPassWord(UserPwdUpdateRequest request);
    }
}
