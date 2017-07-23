using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System.Threading.Tasks;

namespace HealthyInfomation.Facade
{
    public class MedicalIdentificationFacade : RestClientWrapper
    {
        public MedicalIdentificationFacade(WindowBase windowBase)
            : base("MedicalIdentificationWCF", "PhysicalExam", windowBase)
        {
        }

        public async Task<BaseResponse> CreateMedicalIdentification(MedicalIdentificationRequest request)
        {
            return await this.PostAsync<MedicalIdentificationRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateMedicalIdentification(MedicalIdentificationRequest request)
        {
            return await this.PutAsync<MedicalIdentificationRequest, BaseResponse>("update", request);
        }

        public async Task<BaseResponse> RemoveMedicalIdentification(int transactionNumber)
        {
            return await this.DeleteAsync<BaseResponse>(string.Format("remove/{0}", transactionNumber));
        }

        public async Task<MedicalIdentificationEntity> GetMedicalIdentificationByYear(int aircrewID, int year)
        {
            return await this.GetAsync<MedicalIdentificationEntity>(string.Format("get/year/{0}/{1}", aircrewID, year));
        }
    }
}
