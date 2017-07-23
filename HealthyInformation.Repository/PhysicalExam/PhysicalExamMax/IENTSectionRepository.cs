using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface IENTSectionRepository : IRepository<ENTSection>
    {
        ENTSection GetENTSectionByYear(int aircrewID, int year);

        ENTSection GetENTSectionByKey(int transactionNumber);
    }
}
