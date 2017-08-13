using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.Analysis
{
    public interface IAnalysisService
    {
        List<UP_GetHealthyGradeAnalysis_Result> GetGetHealthyGradeAnalysis(int year);
        List<UP_GetHealthyGradeDetail_Result> GetHealthyGradeDetail(int year, int grade);
    }
}
