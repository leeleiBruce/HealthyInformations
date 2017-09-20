using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using HealthyInformation.Service.SystemManage.RecuperationInfor;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“RecuperationInformationWCF”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 RecuperationInformationWCF.svc 或 RecuperationInformationWCF.svc.cs，然后开始调试。
    public class RecuperationInformationWCF : IRecuperationInformationWCF
    {
        IRecuperationAccompanyService recuperationAccompanyService = new RecuperationAccompanyService();
        IRecuperationInformationMemberService recuperationMemberService = new RecuperationInformationMemberService();
        IRecuperationInformationService recuperationInformationService = new RecuperationInformationService();
        public BaseResponse CreateRecuperationInformation(RecuperationInformationRequest request)
        {
            recuperationInformationService.CreateRecuperationInformation(request);
            recuperationMemberService.CreateRecuperationMember(request);
            return recuperationAccompanyService.CreateRecuperationAccompany(request);
        }

        public BaseResponse UpdateRecuperationInformation(RecuperationInformationRequest request)
        {
            recuperationInformationService.UpdateRecuperationInformation(request);
            recuperationMemberService.RemoveRecuperationMember(request.TransactionNumber);
            recuperationMemberService.CreateRecuperationMember(request);
            recuperationAccompanyService.RemoveRecuperationAccompany(request.TransactionNumber);

            return recuperationAccompanyService.CreateRecuperationAccompany(request);
        }

        public List<UP_GetRecuperationPlan_Result> GetRecuperationPlanList(string sanatoriumID, string startDateStr, string endDateStr)
        {
            int sanatoriumId = 0;
            int.TryParse(sanatoriumID, out sanatoriumId);

            DateTime? startDate = null;
            DateTime? endDate = null;

            if (!string.IsNullOrEmpty(startDateStr))
            {
                startDate = DateTime.Parse(startDateStr);
            }

            if (!string.IsNullOrEmpty(endDateStr))
            {
                endDate = DateTime.Parse(endDateStr);
            }

            return recuperationInformationService.GetRecuperationPlanList(sanatoriumId, startDate, endDate);
        }

        public RecuperationInformationResponse GetRecuperationInformation(string key)
        {
            return recuperationInformationService.GetRecuperationInformation(int.Parse(key));
        }

        public void RemoveRecuperationPlanByKey(string key)
        {
            recuperationInformationService.RemoveRecuperationPlanByKey(int.Parse(key));
        }

        public RecuperationDetailResponse GetRecuperationDetail(string key)
        {
            return recuperationInformationService.GetRecuperationDetail(int.Parse(key));
        }

        public List<UP_GetRecuperationInfoAnalysis_Result> GetRecuperationAnalysisResult()
        {
            return recuperationInformationService.GetRecuperationAnalysisResult();
        }

        public UP_GetRecuperationCountAnalysis_Result GetRecuperationAnalysisCountResult()
        {
            return recuperationInformationService.GetRecuperationAnalysisCountResult();
        }
    }
}
