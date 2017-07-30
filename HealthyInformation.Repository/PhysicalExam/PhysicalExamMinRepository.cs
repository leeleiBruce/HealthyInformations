using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam
{
    public class PhysicalExamMinRepository : BaseRepository<PhysicalExamMinRecord>, IPhysicalExamMinRepository
    {
        public PhysicalExamMinRepository(DbContext context) 
            : base(context)
        { }

        public PhysicalExamMinRecord GetPhysicalExamMin(int year)
        {
            return this._context.Set<PhysicalExamMinRecord>().FirstOrDefault(p => p.RecordDate.Year == year);
        }

        public PhysicalExamMinRecord GetPhysicalExamMinRecordByKey(int transactionNumber)
        {
            return this._context.Set<PhysicalExamMinRecord>().FirstOrDefault(p => p.TransactionNumber == transactionNumber);
        }
    }
}
