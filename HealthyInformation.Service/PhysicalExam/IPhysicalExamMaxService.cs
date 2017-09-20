using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IPhysicalExamMaxService : IService<OralCavity>
    {
        OralCavity GetOralCavityByYear(int aircrewID, int year);
        void CreateOralCavity(OralCavityRequest oralCavityRequest);
        void UpdateOralCavity(OralCavityRequest request);
        void RemoveOralCavity(int transactionNumber);
        ENTSection GetENTSectionByYear(int aircrewID, int year);
        void CreateENTSection(ENTSectionRequest request);
        void UpdateENTSection(ENTSectionRequest request);
        void RemoveENTSection(int transactionNumber);
        Phthalmology GetPhthalmologyByYear(int aircrewID, int year);
        void CreatePhthalmology(PhthalmologyRequest request);
        void UpdatePhthalmology(PhthalmologyRequest request);
        void RemovePhthalmology(int transactionNumber);
        Neuropsychiatry GetNeuropsychiatryByYear(int aircrewID, int year);
        void CreateNeuropsychiatry(NeuropsychiatryRequest request);
        void UpdateNeuropsychiatry(NeuropsychiatryRequest request);
        void RemoveNeuropsychiatry(int transactionNumber);
        InternalMedicine GetInternalMedicineByYear(int aircrewID, int year);
        void CreateInternalMedicine(InternalMedicineRequest request);
        void UpdateInternalMedicine(InternalMedicineRequest request);
        void RemoveInternalMedicine(int transactionNumber);
        SkinSurgery GetSkinSurgeryByYear(int aircrewID, int year);
        void CreateSkinSurgery(SkinSurgeryRequest request);
        void UpdateSkinSurgery(SkinSurgeryRequest request);
        void RemoveSkinSurgery(int transactionNumber);
        SupplementaryExam GetSupplementaryExamByYear(int aircrewID, int year);
        void CreateSupplementaryExam(SupplementaryExamRequest request);
        void UpdateSupplementaryExam(SupplementaryExamRequest request);
        void RemoveSupplementaryExam(int transactionNumber);
        ConclusionsPhysical GetConclusionsPhysicalExamByYear(int aircrewID, int year);
        void CreateConclusionPhysical(ConclusionPhysicalRequest request);
        void UpdateConclusionPhysical(ConclusionPhysicalRequest request);
        void RemoveConclusionPhysical(int transactionNumber);

        List<UP_GetPhysicalExamAlarmInfo_Result> GetPhysicalAlarmList();
    }
}
