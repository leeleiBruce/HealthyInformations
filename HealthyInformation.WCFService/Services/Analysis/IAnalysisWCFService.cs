using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HealthyInformation.WCFService.Services.Analysis
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAnalysisWCFService”。
    [ServiceContract]
    public interface IAnalysisWCFService
    {
        [OperationContract]
        [WebGet(UriTemplate = "get?year={year}", ResponseFormat = WebMessageFormat.Json)]
        List<UP_GetHealthyGradeAnalysis_Result> GetGetHealthyGradeAnalysis(string year);

        [WebGet(UriTemplate = "detail/get?year={year}&grade={grade}", ResponseFormat = WebMessageFormat.Json)]
        List<UP_GetHealthyGradeDetail_Result> GetHealthyGradeDetail(string year, string grade);
    }
}
