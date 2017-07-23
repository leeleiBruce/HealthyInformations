using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface ISupplementaryExamRepository : IRepository<SupplementaryExam>
    {
        SupplementaryExam GetSupplementaryExamByYear(int aircrewID, int year);
        SupplementaryExam GetSupplementaryExamByKey(int transactionNumber);
    }
}
