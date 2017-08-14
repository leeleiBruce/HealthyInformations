using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using HealthyInformation.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage.RecuperationInfor
{
    public class RecuperationInformationService : BaseService<RecuperationInformation>, IRecuperationInformationService
    {
        IRecuperationInformationRepository recuperationInformationRepository;
        public RecuperationInformationService()
        {
            recuperationInformationRepository = new RecuperationInformationRepository(this.dbContext);
        }

        public List<UP_GetRecuperationPlan_Result1> GetRecuperationPlanList(int? sanatoriumID, DateTime? startDate, DateTime? endDate)
        {
            return recuperationInformationRepository.GetRecuperationPlanList(sanatoriumID, startDate, endDate);
        }

        public BaseResponse CreateRecuperationInformation(RecuperationInformationRequest request)
        {
            var recuperationInformation = AutoMapper.Mapper.Map<RecuperationInformationRequest, RecuperationInformation>(request);
            recuperationInformation.InDate = DateTime.Now;
            recuperationInformation.LastEditDate = DateTime.Now;
            recuperationInformation.LastEditUser = request.ActionUserID;
            this.Create(recuperationInformation);
            request.TransactionNumber = recuperationInformation.TransactionNumber;
            return this.BuildSuccessResponse();
        }

        public BaseResponse UpdateRecuperationInformation(RecuperationInformationRequest request)
        {
            var recuperationInformation = recuperationInformationRepository.GetRecuperationPlanByKey(request.TransactionNumber);
            recuperationInformation.SanatoriumID = request.SanatoriumID;
            recuperationInformation.HospitalEnterDate = request.HospitalEnterDate;
            recuperationInformation.HospitalLeaveDate = request.HospitalLeaveDate;
            recuperationInformation.LeaderAircrewID = request.LeaderAircrewID;
            recuperationInformation.AviationMedicineID = request.AviationMedicineID;
            recuperationInformation.LastEditDate = DateTime.Now;
            recuperationInformation.LastEditUser= request.ActionUserID;
            this.Update(recuperationInformation);
            return this.BuildSuccessResponse();
        }

        public RecuperationInformationResponse GetRecuperationInformation(int key)
        {
            return recuperationInformationRepository.GetRecuperationInformation(key);
        }

        public void RemoveRecuperationPlanByKey(int key)
        {
            var entity = recuperationInformationRepository.GetRecuperationPlanByKey(key);
            if (entity != null)
            {
                Remove(entity);
            }
        }

        public RecuperationDetailResponse GetRecuperationDetail(int key)
        {
            return recuperationInformationRepository.GetRecuperationDetail(key);
        }

        public List<UP_GetRecuperationInfoAnalysis_Result> GetRecuperationAnalysisResult()
        {
            return recuperationInformationRepository.GetRecuperationAnalysisResult();
        }
        public UP_GetRecuperationCountAnalysis_Result GetRecuperationAnalysisCountResult()
        {
            return recuperationInformationRepository.GetRecuperationAnalysisCountResult();
        }
    }
}
