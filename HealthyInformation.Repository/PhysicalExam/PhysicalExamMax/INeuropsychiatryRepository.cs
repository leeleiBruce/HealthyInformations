using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface INeuropsychiatryRepository : IRepository<Neuropsychiatry>
    {
        Neuropsychiatry GetNeuropsychiatryByYear(int aircrewID, int year);

        Neuropsychiatry GetNeuropsychiatryByKey(int transactionNumber);
    }
}
