using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HealthyInformation.WCFService.Services.PhysicalExam
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAviationAccidentWCF”。
    [ServiceContract]
    public interface IAviationAccidentWCF
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponse CreateAviationAccident(AviationAccidentRequest request);
    }
}
