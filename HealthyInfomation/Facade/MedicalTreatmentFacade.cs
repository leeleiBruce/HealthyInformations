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
        public MedicalTreatmentFacade(WindowBase windowBase, bool isShow = false)
            : base("MedicalTreatmentWCF", "PhysicalExam", windowBase, isShow)
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

        public async Task<List<MedicalTreatmentEntity>> GetMedicalTreatmentByYear(int year)
        {
            return await this.GetAsync<List<MedicalTreatmentEntity>>(string.Format("get/year/{0}", year));
        }

        public async Task<List<MedicalTreatmentEntity>> GetMedicalTreatmentByAlarm()
        {
            return await this.GetAsync<List<MedicalTreatmentEntity>>("get/alarm");
        }

        public async void DeleteMedicalTreatment(int key)
        {
            await this.DeleteAsync<string>(string.Format("delete/{0}", key));
        }
    }
}
