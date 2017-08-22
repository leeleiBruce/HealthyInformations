using HealthyInformation.ClientEntity.SystemManage.Response;
using HealthyInformation.Entity;
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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISanatoriumService”。
    [ServiceContract]
    public interface ISanatoriumService
    {
        [OperationContract]
        [WebGet(UriTemplate = "get?name={name}&pageIndex={pageIndex}&pageSize={pageSize}", ResponseFormat = WebMessageFormat.Json)]
        SanatoriumResponse GetSanatoriumList(string name, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(UriTemplate = "create", ResponseFormat = WebMessageFormat.Json)]
        BaseResponse CreateSanatorium(SanatoriumRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateSanatorium(SanatoriumRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        BaseResponse RemoveSanatorium(string transactionNumber);

        [OperationContract]
        [WebGet(UriTemplate = "single/get?transactionNumber={transactionNumber}", ResponseFormat = WebMessageFormat.Json)]
        Sanatorium GetSanatoriumByKey(string transactionNumber);
    }
}
