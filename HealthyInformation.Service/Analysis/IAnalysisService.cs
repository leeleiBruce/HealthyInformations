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
        List<UP_GetCommonDiseaseAnalysis_Result> GetCommonDiseaseAnalysis(int year);
        List<UP_GetCommonDiseaseDetail_Result> GetCommonDiseaseDetail(int year, int commonDiseaseID);
        List<UP_GetCommonDiseaseCountAnalysis_Result> GetCommonDiseaseCountAnalysis(int year);
        List<UP_GetCommonDiseaseCountDetail_Result> GetCommonDiseaseCountDetail(int year, int commonDiseaseID);
    }
}
