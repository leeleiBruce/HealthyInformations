using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface IConclusionPhysicalRepository : IRepository<ConclusionsPhysical>
    {
        ConclusionsPhysical GetConclusionsPhysicalExamByYear(int aircrewID, int year);

        ConclusionsPhysical GetConclusionsPhysicalExamByKey(int transactionNumber);
    }
}
