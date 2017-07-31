using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HealthyInformation.WCFService.Services.PhysicalExam
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IFlightDiscomfortLevelWCF”。
    [ServiceContract]
    public interface IFlightDiscomfortLevelWCF
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponse CreateFlightDiscomfortableLevel(FlightDiscomfortLevelRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateFlightDiscomfortableLevel(FlightDiscomfortLevelRequest request);

        [OperationContract]
        [WebGet(UriTemplate = "get/year/{year}", ResponseFormat = WebMessageFormat.Json)]
        List<FlightDiscomfortLevel> GetFlightDiscomfortableLevelByYear(string year);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete/{key}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        void DeleteFlightDiscomfortableLevel(string key);
    }
}
