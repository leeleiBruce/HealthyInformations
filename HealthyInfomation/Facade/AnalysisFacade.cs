using HealthyInformation.ClientEntity.Analysis;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInfomation.Facade
{
    public class AnalysisFacade : RestClientWrapper
    {
        public AnalysisFacade(WindowBase windowBase)
            : base("AnalysisWCFService", "Analysis", windowBase)
        {

        }

        public async Task<List<UP_GetHealthyGradeAnalysis_Result>> GetGetHealthyGradeAnalysis(int year)
        {
            return await this.GetAsync<List<UP_GetHealthyGradeAnalysis_Result>>(string.Format("healthyGrade?year={0}", year));
        }

        public async Task<List<UP_GetHealthyGradeDetail_Result>> GetHealthyGradeDetail(int grade, int year)
        {
            return await this.GetAsync<List<UP_GetHealthyGradeDetail_Result>>(string.Format("healthyGrade/detail?year={0}&grade={1}", year, grade));
        }

        public async Task<List<UP_GetCommonDiseaseAnalysis_Result>> GetCommonDiseaseAnalysis(int year)
        {
            return await this.GetAsync<List<UP_GetCommonDiseaseAnalysis_Result>>(string.Format("commonDisease?year={0}", year));
        }

        public async Task<List<UP_GetCommonDiseaseDetail_Result>> GetCommonDiseaseDetail(int year, int commonDiseaseID)
        {
            return await this.GetAsync<List<UP_GetCommonDiseaseDetail_Result>>(string.Format("commonDisease/detail?year={0}&commonDiseaseID={1}", year, commonDiseaseID));
        }

        public async Task<List<UP_GetCommonDiseaseCountAnalysis_Result>> GetCommonDiseaseCountAnalysis(int year)
        {
            return await this.GetAsync<List<UP_GetCommonDiseaseCountAnalysis_Result>>(string.Format("commonDiseaseCount?year={0}", year));
        }

        public async Task<List<UP_GetCommonDiseaseCountDetail_Result>> GetCommonDiseaseCountDetail(int year, int commonDiseaseID)
        {
            return await this.GetAsync<List<UP_GetCommonDiseaseCountDetail_Result>>(string.Format("commonDiseaseCount/detail?year={0}&commonDiseaseID={1}", year, commonDiseaseID));
        }
    }
}
