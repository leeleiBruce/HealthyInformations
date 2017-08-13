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
            return await this.GetAsync<List<UP_GetHealthyGradeAnalysis_Result>>(string.Format("get?year={0}", year));
        }

        public async Task<List<UP_GetHealthyGradeDetail_Result>> GetHealthyGradeDetail(int grade, int year)
        {
            return await this.GetAsync<List<UP_GetHealthyGradeDetail_Result>>(string.Format("detail/get?year={0}&grade={1}", year, grade));
        }
    }
}
