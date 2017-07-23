using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;

namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICommonDiseaseService”。
    [ServiceContract]
    public interface ICommonDiseaseService
    {
        [OperationContract]
        [WebGet(UriTemplate = "get?name={name}&pageIndex={pageIndex}&pageSize={pageSize}", ResponseFormat = WebMessageFormat.Json)]
        CommonDiseaseResponse GetCommonDiseaseList(string name, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(UriTemplate = "create", ResponseFormat = WebMessageFormat.Json)]
        BaseResponse CreateCommonDisease(CommonDiseaseRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateCommonDisease(CommonDiseaseRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete?id={transactionNumber}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        BaseResponse RemoveCommonDisease(string transactionNumber);
    }
}
