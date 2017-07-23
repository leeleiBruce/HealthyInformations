using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Infrastructrue;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using HealthyInformation.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public class DiseaseService : BaseService<CommonDisease>, IDiseaseService
    {
        IDiseaseRepository diseaseRepository;
        public DiseaseService()
        {
            this.diseaseRepository = new DiseaseRepository(this.dbContext);
        }

        public CommonDiseaseResponse GetCommonDisease(string name, int pageIndex, int pageSize)
        {
            var commonDiseaseResult = this.diseaseRepository.GetCommonDisease(name, pageIndex, pageSize);
            return new CommonDiseaseResponse
            {
                CommonDiseaseList = commonDiseaseResult.ToList(),
                TotalCount = commonDiseaseResult.TotalCount
            };
        }

        public BaseResponse CreateCommonDisease(CommonDiseaseRequest request)
        {
            bool isExists = this.diseaseRepository.IsCommonDiseaseExists(request.SymptomName);
            if (isExists)
            {
                return this.BuildErrorResponse("001"); //name has exist
            }

            var commonDisease = new CommonDisease
            {
                SymptomName = request.SymptomName,
                SymptomDetail = request.SymptomDetail,
                Medication = request.Medication,
                TreatmentPlan = request.TreatmentPlan,
                LastEditUser = request.ActionUserID,
                LastEditDate = DateTime.Now,
                InUser = request.ActionUserID,
                InDate = DateTime.Now
            };

            this.diseaseRepository.Create(commonDisease);
            this.unitOfWork.Commit();

            return this.BuildSuccessResponse();
        }

        public BaseResponse UpdateCommonDisease(CommonDiseaseRequest request)
        {
            var commonDisease = this.diseaseRepository.GetCommonDiseaseByKey(request.TransactionNumber);
            if (commonDisease == null)
            {
                return this.BuildErrorResponse("002"); //does not exist
            }

            commonDisease.SymptomName = request.SymptomName;
            commonDisease.SymptomDetail = request.SymptomDetail;
            commonDisease.Medication = request.Medication;
            commonDisease.TreatmentPlan = request.TreatmentPlan;
            commonDisease.LastEditDate = DateTime.Now;
            commonDisease.LastEditUser = request.ActionUserID;
            this.diseaseRepository.Update(commonDisease);
            this.unitOfWork.Commit();

            return this.BuildSuccessResponse();
        }

        public BaseResponse RemoveCommonDisease(int transactionNumber)
        {
            var commonDisease = this.diseaseRepository.GetCommonDiseaseByKey(transactionNumber);
            if (commonDisease != null)
            {
                this.diseaseRepository.Remove(commonDisease);
                this.unitOfWork.Commit();
            }

            return this.BuildSuccessResponse();
        }
    }
}
