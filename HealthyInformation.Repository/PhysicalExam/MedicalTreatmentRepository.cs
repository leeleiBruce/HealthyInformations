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

        public MedicalTreatment GetMedicalTreatmentByYear(int year)
        {
            return this._context.Set<MedicalTreatment>().FirstOrDefault(m => m.RecordDate.Year == year);
        }
    }
}
