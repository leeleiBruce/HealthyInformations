using HealthyInformation.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HealthyInformation.Repository.PhysicalExam
{
    public class MedicalIdentificationRepository : BaseRepository<MedicalIdentification>, IMedicalIdentificationRepository
    {
        public MedicalIdentificationRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public MedicalIdentification GetMedicalIdentification(int aviationMedicineID)
        {
            return this._context.Set<MedicalIdentification>().FirstOrDefault(m => m.AviationMedicineID == aviationMedicineID);
        }

        public MedicalIdentification GetMedicalIdentificationByKey(int transactionNumber)
        {
            return this._context.Set<MedicalIdentification>().SingleOrDefault(m => m.TransactionNumber == transactionNumber);
        }

        public MedicalIdentification GetMedicalIdentificationByYear(int aircrewID, int year)
        {
            return this._context.Set<MedicalIdentification>().FirstOrDefault(m => m.AircrewID == aircrewID && m.RecordDate.Year == year);
        }

        public List<UP_GetPhysicalExamAlarmInfo_Result> GetPhysicalAlarmList()
        {
            return (this._context as HealthyInformationEntities).UP_GetPhysicalExamAlarmInfo().ToList();
        }
    }
}
