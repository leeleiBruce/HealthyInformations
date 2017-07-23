using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class InternalMedicineRepository : BaseRepository<InternalMedicine>, IInternalMedicineRepository
    {
        public InternalMedicineRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public InternalMedicine GetInternalMedicineByYear(int aircrewID, int year)
        {
            return this._context.Set<InternalMedicine>().FirstOrDefault(i => i.AircrewID == aircrewID && i.RecordDate.Value.Year == year);
        }

        public InternalMedicine GetInternalMedicineByKey(int transactionNumber)
        {
            return this._context.Set<InternalMedicine>().FirstOrDefault(i => i.TransactionNumber == transactionNumber);
        }
    }
}
