using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface IInternalMedicineRepository:IRepository<InternalMedicine>
    {
        InternalMedicine GetInternalMedicineByYear(int aircrewID, int year);

        InternalMedicine GetInternalMedicineByKey(int transactionNumber);
    }
}
