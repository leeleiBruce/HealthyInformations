using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface IConclusionPhysicalRepository : IRepository<ConclusionsPhysicalExam>
    {
        ConclusionsPhysicalExam GetConclusionsPhysicalExamByYear(int aircrewID, int year);

        ConclusionsPhysicalExam GetConclusionsPhysicalExamByKey(int transactionNumber);
    }
}
