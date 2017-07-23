using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAircrewService”。
    [ServiceContract]
    public interface IAircrewService
    {
        [OperationContract]
        [WebGet(UriTemplate = "get?name={name}&startDate={startDate}&endDate={endDate}&pageIndex={pageIndex}&pageSize={pageSize}", ResponseFormat = WebMessageFormat.Json)]
        AircrewResponse GetAircrewList(string name, DateTime startDate, DateTime endDate, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        BaseResponse CreateAircrew(AircrewRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateAircrew(AircrewRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "photoupdate", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateAircrewPhoto(AircrewPhotoRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponse RemoveAircrew(string transactionNumber);

        [OperationContract]
        [WebGet(UriTemplate = "flightrecord/get?aircrewID={aircrewID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<FlightRecord> GetFlightRecord(string aircrewID);
    }
}
