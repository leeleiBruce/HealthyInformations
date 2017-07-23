using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.WCFService.Services.PhysicalExam
{
    [ServiceContract]
    public interface IPhysicalExamMinWCF
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        BaseResponse CreatePhysicalExamMin(PhysicalExamMinRecordRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "UPDATE")]
        BaseResponse UpdatePhysicalExamMin(PhysicalExamMinRecordRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "delete", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        BaseResponse RemovePhysicalExamMin(BaseRemoveRequest request);
    }
}
