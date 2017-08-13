using HealthyInformation.Model;
using HealthyInformation.Service.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthyInformation.WCFService.Services.Analysis
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AnalysisWCFService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AnalysisWCFService.svc 或 AnalysisWCFService.svc.cs，然后开始调试。
    public class AnalysisWCFService : IAnalysisWCFService
    {
        IAnalysisService analysisService = new AnalysisService();
        public List<UP_GetHealthyGradeAnalysis_Result> GetGetHealthyGradeAnalysis(string year)
        {
            int convertYear = 0;
            int.TryParse(year, out convertYear);
            return analysisService.GetGetHealthyGradeAnalysis(convertYear);
        }

        public List<UP_GetHealthyGradeDetail_Result> GetHealthyGradeDetail(string year, string grade)
        {
            int convertYear = 0;
            int convertGrade = 0;
            int.TryParse(year, out convertYear);
            int.TryParse(grade, out convertGrade);

            return analysisService.GetHealthyGradeDetail(convertYear, convertGrade);
        }

        public List<UP_GetCommonDiseaseAnalysis_Result> GetCommonDiseaseAnalysis(string year)
        {
            int convertYear = 0;
            int.TryParse(year, out convertYear);
            return analysisService.GetCommonDiseaseAnalysis(convertYear);
        }

        public List<UP_GetCommonDiseaseDetail_Result> GetCommonDiseaseDetail(string year, string commonDiseaseID)
        {
            int convertYear = 0;
            int convertDiseaseID = 0;
            int.TryParse(year, out convertYear);
            int.TryParse(commonDiseaseID, out convertDiseaseID);

            return analysisService.GetCommonDiseaseDetail(convertYear, convertDiseaseID);
        }

        public List<UP_GetCommonDiseaseCountAnalysis_Result> GetCommonDiseaseCountAnalysis(string year)
        {
            int convertYear = 0;
            int.TryParse(year, out convertYear);
            return analysisService.GetCommonDiseaseCountAnalysis(convertYear);
        }

        public List<UP_GetCommonDiseaseCountDetail_Result> GetCommonDiseaseCountDetail(string year, string commonDiseaseID)
        {
            int convertYear = 0;
            int convertDiseaseID = 0;
            int.TryParse(year, out convertYear);
            int.TryParse(commonDiseaseID, out convertDiseaseID);

            return analysisService.GetCommonDiseaseCountDetail(convertYear, convertDiseaseID);
        }
    }
}
