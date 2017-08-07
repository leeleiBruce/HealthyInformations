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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IRecuperationInformationWCF”。
    [ServiceContract]
    public interface IRecuperationInformationWCF
    {
        [OperationContract]
        [WebGet(UriTemplate = "get?sanatoriumID={sanatoriumID}&startDate={startDate}&endDate={endDate}", ResponseFormat = WebMessageFormat.Json)]
        List<UP_GetRecuperationPlan_Result1> GetRecuperationPlanList(string sanatoriumID, string startDate, string endDate);

        [OperationContract]
        [WebInvoke(UriTemplate = "create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST")]
        BaseResponse CreateRecuperationInformation(RecuperationInformationRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateRecuperationInformation(RecuperationInformationRequest request);

        [OperationContract]
        [WebGet(UriTemplate = "report/get/{key}", ResponseFormat = WebMessageFormat.Json)]
        RecuperationInformationResponse GetRecuperationInformation(string key);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete/{key}", Method = "DELETE")]
        void RemoveRecuperationPlanByKey(string key);

        [OperationContract]
        [WebGet(UriTemplate = "detail/get/{key}", ResponseFormat = WebMessageFormat.Json)]
        RecuperationDetailResponse GetRecuperationDetail(string key);

        [OperationContract]
        [WebGet(UriTemplate = "analysis", ResponseFormat = WebMessageFormat.Json)]
        List<UP_GetRecuperationInfoAnalysis_Result> GetRecuperationAnalysisResult();

        [OperationContract]
        [WebGet(UriTemplate = "analysis/count", ResponseFormat = WebMessageFormat.Json)]
        UP_GetRecuperationCountAnalysis_Result GetRecuperationAnalysisCountResult();
    }
}
