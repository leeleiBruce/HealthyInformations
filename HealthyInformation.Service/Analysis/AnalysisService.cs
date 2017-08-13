using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        public List<UP_GetHealthyGradeAnalysis_Result> GetGetHealthyGradeAnalysis(int year)
        {
            using (HealthyInformationEntities entities = new HealthyInformationEntities())
            {
                return entities.UP_GetHealthyGradeAnalysis(year).ToList();
            }
        }

        public List<UP_GetHealthyGradeDetail_Result> GetHealthyGradeDetail(int year,int grade)
        {
            using (HealthyInformationEntities entities = new HealthyInformationEntities())
            {
                return entities.UP_GetHealthyGradeDetail(grade,year).ToList();
            }
        }
    }
}
