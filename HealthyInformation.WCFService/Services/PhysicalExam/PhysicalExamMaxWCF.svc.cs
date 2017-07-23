using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using HealthyInformation.Service.PhysicalExam;
using System.Collections.Generic;

namespace HealthyInformation.WCFService.Services.PhysicalExam
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PhysicalExamMaxWCF”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PhysicalExamMaxWCF.svc 或 PhysicalExamMaxWCF.svc.cs，然后开始调试。
    public class PhysicalExamMaxWCF : IPhysicalExamMaxWCF
    {
        IPhysicalExamMaxService physicalExamMaxService = new PhysicalExamMaxService();

        #region get
        public OralCavity GetOralCavity(string aircrewID, string year)
        {
            return physicalExamMaxService.GetOralCavityByYear(int.Parse(aircrewID), int.Parse(year));
        }

        public ENTSection GetENTSection(string aircrewID, string year)
        {
            return physicalExamMaxService.GetENTSectionByYear(int.Parse(aircrewID), int.Parse(year));
        }

        public Phthalmology GetPhthalmology(string aircrewID, string year)
        {
            return physicalExamMaxService.GetPhthalmologyByYear(int.Parse(aircrewID), int.Parse(year));
        }

        public Neuropsychiatry GetNeuropsychiatry(string aircrewID, string year)
        {
            return physicalExamMaxService.GetNeuropsychiatryByYear(int.Parse(aircrewID), int.Parse(year));
        }

        public InternalMedicine GetInternalMedicine(string aircrewID, string year)
        {
            return physicalExamMaxService.GetInternalMedicineByYear(int.Parse(aircrewID), int.Parse(year));
        }

        public SkinSurgery GetSkinSurgery(string aircrewID, string year)
        {
            return physicalExamMaxService.GetSkinSurgeryByYear(int.Parse(aircrewID), int.Parse(year));
        }

        public SupplementaryExam GetSupplementaryExam(string aircrewID, string year)
        {
            return physicalExamMaxService.GetSupplementaryExamByYear(int.Parse(aircrewID), int.Parse(year));
        }

        public ConclusionsPhysicalExam GetConclusionsPhysicalExam(string aircrewID, string year)
        {
            return physicalExamMaxService.GetConclusionsPhysicalExamByYear(int.Parse(aircrewID), int.Parse(year));
        }

        #endregion

        #region create

        public void CreateOralCavity(OralCavityRequest request)
        {
            physicalExamMaxService.CreateOralCavity(request);
        }

        public void CreateENTSection(ENTSectionRequest request)
        {
            physicalExamMaxService.CreateENTSection(request);
        }

        public void CreatePhthalmology(PhthalmologyRequest request)
        {
            physicalExamMaxService.CreatePhthalmology(request);
        }

        public void CreateNeuropsychiatry(NeuropsychiatryRequest request)
        {
            physicalExamMaxService.CreateNeuropsychiatry(request);
        }

        public void CreateInternalMedicine(InternalMedicineRequest request)
        {
            physicalExamMaxService.CreateInternalMedicine(request);
        }

        public void CreateSkinSurgery(SkinSurgeryRequest request)
        {
            physicalExamMaxService.CreateSkinSurgery(request);
        }

        public void CreateSupplementaryExam(SupplementaryExamRequest request)
        {
            physicalExamMaxService.CreateSupplementaryExam(request);
        }

        public void CreateConclusionPhysicalExam(ConclusionPhysicalRequest request)
        {
            physicalExamMaxService.CreateConclusionPhysical(request);
        }

        #endregion

        #region update

        public void UpdateOralCavity(OralCavityRequest request)
        {
            physicalExamMaxService.UpdateOralCavity(request);
        }

        public void UpdateENTSection(ENTSectionRequest request)
        {
            physicalExamMaxService.UpdateENTSection(request);
        }

        public void UpdatePhthalmology(PhthalmologyRequest request)
        {
            physicalExamMaxService.UpdatePhthalmology(request);
        }

        public void UpdateNeuropsychiatry(NeuropsychiatryRequest request)
        {
            physicalExamMaxService.UpdateNeuropsychiatry(request);
        }

        public void UpdateInternalMedicine(InternalMedicineRequest request)
        {
            physicalExamMaxService.UpdateInternalMedicine(request);
        }

        public void UpdateSkinSurgery(SkinSurgeryRequest request)
        {
            physicalExamMaxService.UpdateSkinSurgery(request);
        }

        public void UpdateSupplementaryExam(SupplementaryExamRequest request)
        {
            physicalExamMaxService.UpdateSupplementaryExam(request);
        }

        public void UpdateConclusionPhysicalExam(ConclusionPhysicalRequest request)
        {
            physicalExamMaxService.UpdateConclusionPhysical(request);
        }

        #endregion

        #region remove

        public void RemoveOralCavity(string transactionNumber)
        {
            physicalExamMaxService.RemoveOralCavity(int.Parse(transactionNumber));
        }

        public void RemoveENTSection(string transactionNumber)
        {
            physicalExamMaxService.RemoveENTSection(int.Parse(transactionNumber));
        }

        public void RemovePhthalmology(string transactionNumber)
        {
            physicalExamMaxService.RemovePhthalmology(int.Parse(transactionNumber));
        }

        public void RemoveNeuropsychiatry(string transactionNumber)
        {
            physicalExamMaxService.RemoveNeuropsychiatry(int.Parse(transactionNumber));
        }

        public void RemoveInternalMedicine(string transactionNumber)
        {
            physicalExamMaxService.RemoveInternalMedicine(int.Parse(transactionNumber));
        }

        public void RemoveSkinSurgery(string transactionNumber)
        {
            physicalExamMaxService.RemoveSkinSurgery(int.Parse(transactionNumber));
        }

        public void RemoveSupplementaryExam(string transactionNumber)
        {
            physicalExamMaxService.RemoveSupplementaryExam(int.Parse(transactionNumber));
        }

        public void RemoveConclusionPhysicalExam(string transactionNumber)
        {
            physicalExamMaxService.RemoveConclusionPhysical(int.Parse(transactionNumber));
        }

        #endregion

        public List<UP_GetPhysicalExamAlarmInfo_Result> GetPhysicalAlarmList()
        {
            return physicalExamMaxService.GetPhysicalAlarmList();
        }

    }
}
