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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IConfigDictionaryService”。
    [ServiceContract]
    public interface IConfigDictionaryWCF
    {
        [OperationContract]
        [WebGet(UriTemplate = "get", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<FlyerType> GetFlyerTypeList();

        [OperationContract]
        [WebInvoke(UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        int CreateFlyerType(FlyerTypeRequest flyerTypeRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        int UpdateFlyerType(FlyerTypeRequest flyerTypeRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        int DeleteFlyerType(string transactionNumber);
    }
}
