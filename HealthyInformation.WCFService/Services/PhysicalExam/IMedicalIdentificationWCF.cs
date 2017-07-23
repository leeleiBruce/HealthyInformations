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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMedicalIdentification”。
    [ServiceContract]
    public interface IMedicalIdentificationWCF
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        BaseResponse CreateMedicalIdentification(MedicalIdentificationRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        BaseResponse UpdateMedicalIdentification(MedicalIdentificationRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "remove/{transactionNumber}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        BaseResponse RemoveMedicalIdentification(string transactionNumber);

        [OperationContract]
        [WebGet(UriTemplate = "get?aircrewID={aircrewID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        MedicalIdentification GetMedicalIdentification(int aircrewID);

        [OperationContract]
        [WebGet(UriTemplate = "get/year/{aircrewID}/{year}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        MedicalIdentification GetMedicalIdentificationByYear(string aircrewID, string year);
    }
}
