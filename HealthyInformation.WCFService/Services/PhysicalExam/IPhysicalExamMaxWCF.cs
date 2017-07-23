using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HealthyInformation.WCFService.Services.PhysicalExam
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPhysicalExamMaxWCF”。
    [ServiceContract]
    public interface IPhysicalExamMaxWCF
    {
        #region get
        [OperationContract]
        [WebGet(UriTemplate = "oralcavity/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        OralCavity GetOralCavity(string aircrewID, string year);

        [OperationContract]
        [WebGet(UriTemplate = "ENTSection/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ENTSection GetENTSection(string aircrewID, string year);

        [OperationContract]
        [WebGet(UriTemplate = "phthalmology/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Phthalmology GetPhthalmology(string aircrewID, string year);

        [OperationContract]
        [WebGet(UriTemplate = "neuropsychiatry/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Neuropsychiatry GetNeuropsychiatry(string aircrewID, string year);

        [OperationContract]
        [WebGet(UriTemplate = "internalmedicine/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        InternalMedicine GetInternalMedicine(string aircrewID, string year);

        [OperationContract]
        [WebGet(UriTemplate = "skinsurgery/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        SkinSurgery GetSkinSurgery(string aircrewID, string year);

        [OperationContract]
        [WebGet(UriTemplate = "supplementaryexam/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        SupplementaryExam GetSupplementaryExam(string aircrewID, string year);

        [OperationContract]
        [WebGet(UriTemplate = "conclusionsphysicalexam/year/{aircrewID}/{year}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ConclusionsPhysicalExam GetConclusionsPhysicalExam(string aircrewID, string year);
        #endregion

        #region create
        [OperationContract]
        [WebInvoke(UriTemplate = "oralcavity/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreateOralCavity(OralCavityRequest oralCavity);

        [OperationContract]
        [WebInvoke(UriTemplate = "entsection/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreateENTSection(ENTSectionRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "phthalmology/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreatePhthalmology(PhthalmologyRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "neuropsychiatry/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreateNeuropsychiatry(NeuropsychiatryRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "internalmedicine/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreateInternalMedicine(InternalMedicineRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "skinsurgery/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreateSkinSurgery(SkinSurgeryRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "supplementaryexam/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreateSupplementaryExam(SupplementaryExamRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "conclusionphysical/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void CreateConclusionPhysicalExam(ConclusionPhysicalRequest request);

        #endregion

        #region update

        [OperationContract]
        [WebInvoke(UriTemplate = "oralcavity/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateOralCavity(OralCavityRequest oralCavity);

        [OperationContract]
        [WebInvoke(UriTemplate = "entsection/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateENTSection(ENTSectionRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "phthalmology/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdatePhthalmology(PhthalmologyRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "neuropsychiatry/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateNeuropsychiatry(NeuropsychiatryRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "internalmedicine/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateInternalMedicine(InternalMedicineRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "skinsurgery/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateSkinSurgery(SkinSurgeryRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "supplementaryexam/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateSupplementaryExam(SupplementaryExamRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "conclusionphysical/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT")]
        void UpdateConclusionPhysicalExam(ConclusionPhysicalRequest request);

        #endregion

        #region remove

        [OperationContract]
        [WebInvoke(UriTemplate = "oralcavity/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemoveOralCavity(string transactionNumber);

        [OperationContract]
        [WebInvoke(UriTemplate = "entsection/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemoveENTSection(string transactionNumber);

        [OperationContract]
        [WebInvoke(UriTemplate = "phthalmology/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemovePhthalmology(string transactionNumber);

        [OperationContract]
        [WebInvoke(UriTemplate = "neuropsychiatry/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemoveNeuropsychiatry(string transactionNumber);

        [OperationContract]
        [WebInvoke(UriTemplate = "internalmedicine/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemoveInternalMedicine(string transactionNumber);

        [OperationContract]
        [WebInvoke(UriTemplate = "skinsurgery/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemoveSkinSurgery(string transactionNumber);

        [OperationContract]
        [WebInvoke(UriTemplate = "supplementaryexam/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemoveSupplementaryExam(string transactionNumber);

        [OperationContract]
        [WebInvoke(UriTemplate = "conclusionphysical/remove/{transactionNumber}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "DELETE")]
        void RemoveConclusionPhysicalExam(string transactionNumber);

        #endregion

        [OperationContract]
        [WebGet(UriTemplate= "PhysicalAlarm/get", ResponseFormat = WebMessageFormat.Json)]
        List<UP_GetPhysicalExamAlarmInfo_Result> GetPhysicalAlarmList();
    }
}
