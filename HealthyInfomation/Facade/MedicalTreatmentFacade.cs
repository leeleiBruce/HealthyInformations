using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInfomation.Facade
{
    public class MedicalTreatmentFacade : RestClientWrapper
    {
        public MedicalTreatmentFacade(WindowBase windowBase)
            : base("MedicalTreatmentWCF", "PhysicalExam", windowBase)
        {

        }

        public async Task<BaseResponse> CreateMedicalTreatment(MedicalTreatmentRequest request)
        {
            return await this.PostAsync<MedicalTreatmentRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateMedicalTreatment(MedicalTreatmentRequest request)
        {
            return await this.PutAsync<MedicalTreatmentRequest, BaseResponse>("update", request);
        }

        public async Task<MedicalTreatmentEntity> GetMedicalTreatmentByYear(int year)
        {
            return await this.GetAsync<MedicalTreatmentEntity>(string.Format("get/year/{0}", year));
        }
    }
}
