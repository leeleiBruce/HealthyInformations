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

        public List<UP_GetHealthyGradeDetail_Result> GetHealthyGradeDetail(int year, int grade)
        {
            using (HealthyInformationEntities entities = new HealthyInformationEntities())
            {
                return entities.UP_GetHealthyGradeDetail(grade, year).ToList();
            }
        }

        public List<UP_GetCommonDiseaseAnalysis_Result> GetCommonDiseaseAnalysis(int year)
        {
            using (HealthyInformationEntities entities = new HealthyInformationEntities())
            {
                return entities.UP_GetCommonDiseaseAnalysis(year).ToList();
            }
        }

        public List<UP_GetCommonDiseaseDetail_Result> GetCommonDiseaseDetail(int year, int commonDiseaseID)
        {
            using (HealthyInformationEntities entities = new HealthyInformationEntities())
            {
                return entities.UP_GetCommonDiseaseDetail(year, commonDiseaseID).ToList();
            }
        }

        public List<UP_GetCommonDiseaseCountAnalysis_Result> GetCommonDiseaseCountAnalysis(int year)
        {
            using (HealthyInformationEntities entities = new HealthyInformationEntities())
            {
                return entities.UP_GetCommonDiseaseCountAnalysis(year).ToList();
            }
        }

        public List<UP_GetCommonDiseaseCountDetail_Result> GetCommonDiseaseCountDetail(int year, int commonDiseaseID)
        {
            using (HealthyInformationEntities entities = new HealthyInformationEntities())
            {
                return entities.UP_GetCommonDiseaseCountDetail(year, commonDiseaseID).ToList();
            }
        }
    }
}
