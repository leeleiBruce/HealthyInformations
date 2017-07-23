using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAviationMedicineService”。
    [ServiceContract]
    public interface IAviationMedicineService
    {
        [OperationContract]
        [WebGet(UriTemplate = "get?name={name}&pageIndex={pageIndex}&pageSize={pageSize}",
            ResponseFormat = WebMessageFormat.Json)]
        AviationMedicineResponse GetAviationMedicineList(string name, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(UriTemplate = "create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST")]
        BaseResponse CreateAviationMedicine(AviationMedicineRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateAviationMedicine(AviationMedicineRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete?id={transactionNumber}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        BaseResponse RemoveAviationMedicine(string transactionNumber);
    }
}
