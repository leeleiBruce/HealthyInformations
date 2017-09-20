using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository.PhysicalExam;
using HealthyInformation.Repository.PhysicalExam.PhysicalExamMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public class PhysicalExamMaxService : BaseService<OralCavity>, IPhysicalExamMaxService
    {
        IMedicalIdentificationRepository medicalIdentificationRepository;
        IOralCavityRepository oralCavityRepository;
        IENTSectionRepository _ENTSectionRepository;
        IPhthalmologyRepository phthalmologyRepository;
        INeuropsychiatryRepository neuropsychiatryRepository;
        IInternalMedicineRepository internalMedicineRepository;
        ISkinSurgeryRepository skinSurgeryRepository;
        ISupplementaryExamRepository supplementaryExamRepository;
        IConclusionPhysicalRepository conclusionPhysicalRepository;
        public PhysicalExamMaxService()
        {
            oralCavityRepository = new OralCavityRepository(this.dbContext);
            _ENTSectionRepository = new ENTSectionRepository(this.dbContext);
            phthalmologyRepository = new PhthalmologyRepository(this.dbContext);
            neuropsychiatryRepository = new NeuropsychiatryRepository(this.dbContext);
            internalMedicineRepository = new InternalMedicineRepository(this.dbContext);
            skinSurgeryRepository = new SkinSurgeryRepository(this.dbContext);
            supplementaryExamRepository = new SupplementaryExamRepository(this.dbContext);
            conclusionPhysicalRepository = new ConclusionPhysicalRepository(this.dbContext);
            medicalIdentificationRepository = new MedicalIdentificationRepository(this.dbContext);
        }

        #region OralCavity
        public OralCavity GetOralCavityByYear(int aircrewID, int year)
        {
            return oralCavityRepository.GetOralCavityByYear(aircrewID, year);
        }

        public void CreateOralCavity(OralCavityRequest request)
        {
            var oralCavity = AutoMapper.Mapper.Map<OralCavityRequest, OralCavity>(request);
            oralCavityRepository.Create(oralCavity);
            unitOfWork.Commit();
        }

        public void UpdateOralCavity(OralCavityRequest request)
        {
            var oralCavity = AutoMapper.Mapper.Map<OralCavityRequest, OralCavity>(request);
            oralCavityRepository.Update(oralCavity);
            unitOfWork.Commit();
        }

        public void RemoveOralCavity(int transactionNumber)
        {
            var oralCavity = oralCavityRepository.GetOralCavityByKey(transactionNumber);
            if (oralCavity != null)
            {
                oralCavityRepository.Remove(oralCavity);
                unitOfWork.Commit();
            }
        }

        #endregion

        #region ENTSection
        public ENTSection GetENTSectionByYear(int aircrewID, int year)
        {
            return _ENTSectionRepository.GetENTSectionByYear(aircrewID, year);
        }

        public void CreateENTSection(ENTSectionRequest request)
        {
            var _ENTSection = AutoMapper.Mapper.Map<ENTSectionRequest, ENTSection>(request);
            _ENTSectionRepository.Create(_ENTSection);
            unitOfWork.Commit();
        }

        public void UpdateENTSection(ENTSectionRequest request)
        {
            var _ENTSection = AutoMapper.Mapper.Map<ENTSectionRequest, ENTSection>(request);
            _ENTSectionRepository.Update(_ENTSection);
            unitOfWork.Commit();
        }

        public void RemoveENTSection(int transactionNumber)
        {
            var _ENTSection = _ENTSectionRepository.GetENTSectionByKey(transactionNumber);
            if (_ENTSection != null)
            {
                _ENTSectionRepository.Remove(_ENTSection);
                unitOfWork.Commit();
            }
        }

        #endregion

        #region Phthalmology
        public Phthalmology GetPhthalmologyByYear(int aircrewID, int year)
        {
            return phthalmologyRepository.GetPhthalmologyByYear(aircrewID, year);
        }

        public void CreatePhthalmology(PhthalmologyRequest request)
        {
            var phthalmology = AutoMapper.Mapper.Map<PhthalmologyRequest, Phthalmology>(request);
            phthalmologyRepository.Create(phthalmology);
            unitOfWork.Commit();
        }

        public void UpdatePhthalmology(PhthalmologyRequest request)
        {
            var phthalmology = AutoMapper.Mapper.Map<PhthalmologyRequest, Phthalmology>(request);
            phthalmologyRepository.Update(phthalmology);
            unitOfWork.Commit();
        }

        public void RemovePhthalmology(int transactionNumber)
        {
            var phthalmology = phthalmologyRepository.GetPhthalmologyByKey(transactionNumber);
            if (phthalmology != null)
            {
                phthalmologyRepository.Remove(phthalmology);
                unitOfWork.Commit();
            }
        }

        #endregion

        #region Neuropsychiatry
        public Neuropsychiatry GetNeuropsychiatryByYear(int aircrewID, int year)
        {
            return neuropsychiatryRepository.GetNeuropsychiatryByYear(aircrewID, year);
        }

        public void CreateNeuropsychiatry(NeuropsychiatryRequest request)
        {
            var neuropsychiatry = AutoMapper.Mapper.Map<NeuropsychiatryRequest, Neuropsychiatry>(request);
            neuropsychiatryRepository.Create(neuropsychiatry);
            unitOfWork.Commit();
        }

        public void UpdateNeuropsychiatry(NeuropsychiatryRequest request)
        {
            var neuropsychiatry = AutoMapper.Mapper.Map<NeuropsychiatryRequest, Neuropsychiatry>(request);
            neuropsychiatryRepository.Update(neuropsychiatry);
            unitOfWork.Commit();
        }

        public void RemoveNeuropsychiatry(int transactionNumber)
        {
            var neuropsychiatry = neuropsychiatryRepository.GetNeuropsychiatryByKey(transactionNumber);
            if (neuropsychiatry != null)
            {
                neuropsychiatryRepository.Remove(neuropsychiatry);
                unitOfWork.Commit();
            }
        }

        #endregion

        #region InternalMedicine
        public InternalMedicine GetInternalMedicineByYear(int aircrewID, int year)
        {
            return internalMedicineRepository.GetInternalMedicineByYear(aircrewID, year);
        }

        public void CreateInternalMedicine(InternalMedicineRequest request)
        {
            var internalMedicine = AutoMapper.Mapper.Map<InternalMedicineRequest, InternalMedicine>(request);
            internalMedicineRepository.Create(internalMedicine);
            unitOfWork.Commit();
        }

        public void UpdateInternalMedicine(InternalMedicineRequest request)
        {
            var internalMedicine = AutoMapper.Mapper.Map<InternalMedicineRequest, InternalMedicine>(request);
            internalMedicineRepository.Update(internalMedicine);
            unitOfWork.Commit();
        }

        public void RemoveInternalMedicine(int transactionNumber)
        {
            var internalMedicine = internalMedicineRepository.GetInternalMedicineByKey(transactionNumber);
            if (internalMedicine != null)
            {
                internalMedicineRepository.Remove(internalMedicine);
                unitOfWork.Commit();
            }
        }

        #endregion

        #region SkinSurgery
        public SkinSurgery GetSkinSurgeryByYear(int aircrewID, int year)
        {
            return skinSurgeryRepository.GetSkinSurgeryByYear(aircrewID, year);
        }

        public void CreateSkinSurgery(SkinSurgeryRequest request)
        {
            var skinSurgery = AutoMapper.Mapper.Map<SkinSurgeryRequest, SkinSurgery>(request);
            skinSurgeryRepository.Create(skinSurgery);
            unitOfWork.Commit();
        }

        public void UpdateSkinSurgery(SkinSurgeryRequest request)
        {
            var skinSurgery = AutoMapper.Mapper.Map<SkinSurgeryRequest, SkinSurgery>(request);
            skinSurgeryRepository.Update(skinSurgery);
            unitOfWork.Commit();
        }

        public void RemoveSkinSurgery(int transactionNumber)
        {
            var skinSurgery = skinSurgeryRepository.GetSkinSurgeryByKey(transactionNumber);
            if (skinSurgery != null)
            {
                skinSurgeryRepository.Remove(skinSurgery);
                unitOfWork.Commit();
            }
        }

        #endregion

        #region SupplementaryExam
        public SupplementaryExam GetSupplementaryExamByYear(int aircrewID, int year)
        {
            return supplementaryExamRepository.GetSupplementaryExamByYear(aircrewID, year);
        }

        public void CreateSupplementaryExam(SupplementaryExamRequest request)
        {
            var supplementaryExam = AutoMapper.Mapper.Map<SupplementaryExamRequest, SupplementaryExam>(request);
            supplementaryExamRepository.Create(supplementaryExam);
            unitOfWork.Commit();
        }

        public void UpdateSupplementaryExam(SupplementaryExamRequest request)
        {
            var supplementaryExam = AutoMapper.Mapper.Map<SupplementaryExamRequest, SupplementaryExam>(request);
            supplementaryExamRepository.Update(supplementaryExam);
            unitOfWork.Commit();
        }

        public void RemoveSupplementaryExam(int transactionNumber)
        {
            var supplementaryExam = supplementaryExamRepository.GetSupplementaryExamByKey(transactionNumber);
            if (supplementaryExam != null)
            {
                supplementaryExamRepository.Remove(supplementaryExam);
                unitOfWork.Commit();
            }
        }

        #endregion

        #region ConclusionsPhysicalExam
        public ConclusionsPhysical GetConclusionsPhysicalExamByYear(int aircrewID, int year)
        {
            return conclusionPhysicalRepository.GetConclusionsPhysicalExamByYear(aircrewID, year);
        }

        public void CreateConclusionPhysical(ConclusionPhysicalRequest request)
        {
            var conclusionPhysical = AutoMapper.Mapper.Map<ConclusionPhysicalRequest, ConclusionsPhysical>(request);
            conclusionPhysicalRepository.Create(conclusionPhysical);
            unitOfWork.Commit();
        }

        public void UpdateConclusionPhysical(ConclusionPhysicalRequest request)
        {
            var conclusionPhysical = AutoMapper.Mapper.Map<ConclusionPhysicalRequest, ConclusionsPhysical>(request);
            conclusionPhysicalRepository.Update(conclusionPhysical);
            unitOfWork.Commit();
        }

        public void RemoveConclusionPhysical(int transactionNumber)
        {
            var conclusionPhysical = conclusionPhysicalRepository.GetConclusionsPhysicalExamByKey(transactionNumber);
            if (conclusionPhysical != null)
            {
                conclusionPhysicalRepository.Remove(conclusionPhysical);
                unitOfWork.Commit();
            }
        }
        #endregion

        public List<UP_GetPhysicalExamAlarmInfo_Result> GetPhysicalAlarmList()
        {
            return medicalIdentificationRepository.GetPhysicalAlarmList();
        }
    }
}
