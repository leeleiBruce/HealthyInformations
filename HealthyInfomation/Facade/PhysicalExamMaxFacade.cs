using HealthyInformation.ClientEntity.PhysicalExam.Entity;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyInfomation.Facade
{
    public class PhysicalExamMaxFacade : RestClientWrapper
    {
        public PhysicalExamMaxFacade(WindowBase windowBase)
            : base("PhysicalExamMaxWCF", "PhysicalExam", windowBase)
        {
        }

        #region get
        public async Task<OralCavityEntity> GetOralCavity(int airecrewID, int year)
        {
            return await this.GetAsync<OralCavityEntity>(string.Format("oralcavity/year/{0}/{1}", airecrewID, year));
        }

        public async Task<ENTSectionEntity> GetENTSection(int airecrewID, int year)
        {
            return await this.GetAsync<ENTSectionEntity>(string.Format("ENTSection/year/{0}/{1}", airecrewID, year));
        }

        public async Task<PhthalmologyEntity> GetPhthalmology(int airecrewID, int year)
        {
            return await this.GetAsync<PhthalmologyEntity>(string.Format("phthalmology/year/{0}/{1}", airecrewID, year));
        }

        public async Task<NeuropsychiatryEntity> GetNeuropsychiatry(int airecrewID, int year)
        {
            return await this.GetAsync<NeuropsychiatryEntity>(string.Format("neuropsychiatry/year/{0}/{1}", airecrewID, year));
        }

        public async Task<InternalMedicineEntity> GetInternalMedicine(int airecrewID, int year)
        {
            return await this.GetAsync<InternalMedicineEntity>(string.Format("internalmedicine/year/{0}/{1}", airecrewID, year));
        }

        public async Task<SkinSurgeryEntity> GetSkinSurgery(int airecrewID, int year)
        {
            return await this.GetAsync<SkinSurgeryEntity>(string.Format("skinsurgery/year/{0}/{1}", airecrewID, year));
        }

        public async Task<SupplementaryExamEntity> GetSupplementaryExam(int airecrewID, int year)
        {
            return await this.GetAsync<SupplementaryExamEntity>(string.Format("supplementaryexam/year/{0}/{1}", airecrewID, year));
        }

        public async Task<ConclusionsphysicalexamEntity> GetConclusionsphysical(int airecrewID, int year)
        {
            return await this.GetAsync<ConclusionsphysicalexamEntity>(string.Format("conclusionsphysicalexam/year/{0}/{1}", airecrewID, year));
        }

        #endregion

        #region create

        public async Task CreateOralCavity(OralCavityRequest request)
        {
            await this.PostAsync<OralCavityRequest, string>("oralcavity/create", request);
        }

        public async Task CreateENTSection(ENTSectionRequest request)
        {
            await this.PostAsync<ENTSectionRequest, string>("entsection/create", request);
        }

        public async Task CreateOphthalmology(PhthalmologyRequest request)
        {
            await this.PostAsync<PhthalmologyRequest, string>("phthalmology/create", request);
        }

        public async Task CreateNeuropsychiatry(NeuropsychiatryRequest request)
        {
            await this.PostAsync<NeuropsychiatryRequest, string>("neuropsychiatry/create", request);
        }

        public async Task CreateInternalMedicine(InternalMedicineRequest request)
        {
            await this.PostAsync<InternalMedicineRequest, string>("internalmedicine/create", request);
        }

        public async Task CreateSkinSurgery(SkinSurgeryRequest request)
        {
            await this.PostAsync<SkinSurgeryRequest, string>("skinsurgery/create", request);
        }

        public async Task CreateSupplementaryExam(SupplementaryExamRequest request)
        {
            await this.PostAsync<SupplementaryExamRequest, string>("supplementaryexam/create", request);
        }

        public async Task CreateConclusionPhysical(ConclusionPhysicalRequest request)
        {
            await this.PostAsync<ConclusionPhysicalRequest, string>("conclusionphysical/create", request);
        }

        #endregion

        #region update

        public async Task UpdateOralCavity(OralCavityRequest request)
        {
            await this.PutAsync<OralCavityRequest, string>("oralcavity/update", request);
        }

        public async Task UpdateENTSection(ENTSectionRequest request)
        {
            await this.PutAsync<ENTSectionRequest, string>("entsection/update", request);
        }

        public async Task UpdateOphthalmology(PhthalmologyRequest request)
        {
            await this.PutAsync<PhthalmologyRequest, string>("phthalmology/update", request);
        }

        public async Task UpdateNeuropsychiatry(NeuropsychiatryRequest request)
        {
            await this.PutAsync<NeuropsychiatryRequest, string>("neuropsychiatry/update", request);
        }

        public async Task UpdateInternalMedicine(InternalMedicineRequest request)
        {
            await this.PutAsync<InternalMedicineRequest, string>("internalmedicine/update", request);
        }

        public async Task UpdateSkinSurgery(SkinSurgeryRequest request)
        {
            await this.PutAsync<SkinSurgeryRequest, string>("skinsurgery/update", request);
        }

        public async Task UpdateSupplementaryExam(SupplementaryExamRequest request)
        {
            await this.PutAsync<SupplementaryExamRequest, string>("supplementaryexam/update", request);
        }

        public async Task UpdateConclusionPhysical(ConclusionPhysicalRequest request)
        {
            await this.PutAsync<ConclusionPhysicalRequest, string>("conclusionphysical/update", request);
        }

        #endregion

        #region remove
        public async Task RemoveOralCavity(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("oralcavity/remove/{0}", transactionNumber));
        }

        public async Task RemoveENTSection(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("entsection/remove/{0}", transactionNumber));
        }

        public async Task RemoveOphthalmology(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("phthalmology/remove/{0}", transactionNumber));
        }

        public async Task RemoveNeuropsychiatry(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("neuropsychiatry/remove/{0}", transactionNumber));
        }

        public async Task RemoveInternalMedicine(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("internalmedicine/remove/{0}", transactionNumber));
        }

        public async Task RemoveSkinSurgery(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("skinsurgery/remove/{0}", transactionNumber));
        }

        public async Task RemoveSupplementaryExam(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("supplementaryexam/remove/{0}", transactionNumber));
        }

        public async Task RemoveConclusionPhysical(int transactionNumber)
        {
            await this.DeleteAsync<string>(string.Format("conclusionphysical/remove/{0}", transactionNumber));
        }
        #endregion

        public async Task<List<UP_GetPhysicalExamAlarmInfo_Result>> GetPhysicalExamAlarm()
        {
            return await this.GetAsync<List<UP_GetPhysicalExamAlarmInfo_Result>>("PhysicalAlarm/get");
        }
    }
}
