using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public class SkinSurgeryRepository : BaseRepository<SkinSurgery>, ISkinSurgeryRepository
    {
        public SkinSurgeryRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public SkinSurgery GetSkinSurgeryByYear(int aircrewID, int year)
        {
            return this._context.Set<SkinSurgery>().FirstOrDefault(s => s.AircrewID == aircrewID && s.RecordDate.Value.Year == year);
        }

        public SkinSurgery GetSkinSurgeryByKey(int transactionNumber)
        {
            return this._context.Set<SkinSurgery>().FirstOrDefault(s => s.TransactionNumber == transactionNumber);
        }
    }
}
