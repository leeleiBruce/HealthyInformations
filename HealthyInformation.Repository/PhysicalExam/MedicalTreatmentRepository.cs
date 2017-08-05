using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam
{
    public class MedicalTreatmentRepository : BaseRepository<MedicalTreatment>, IMedicalTreatmentRepository
    {
        public MedicalTreatmentRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public MedicalTreatment GetMedicalTreatmentByKey(int medicalTreatId)
        {
            return this._context.Set<MedicalTreatment>().FirstOrDefault(m => m.TransactionNumber == medicalTreatId);
        }

        public List<MedicalTreatment> GetMedicalTreatmentByYear(int year)
        {
            return this._context.Set<MedicalTreatment>().Where(m => m.RecordDate.Year == year).ToList();
        }

        public List<MedicalTreatment> GetMedicalTreatmentByAlarmDate()
        {
            var date = DateTime.Now.AddMonths(1);
            return this._context.Set<MedicalTreatment>()
                .Where(m => m.NeedObservation == "1"
                && m.ObservationEndDate.HasValue
                && date >= m.ObservationEndDate.Value
                && m.ObservationEndDate >= DateTime.Now).ToList();
        }
    }
}
