using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.SystemManage
{
    public interface IAviationMedicineRepository : IRepository<AviationMedicine>
    {
        IPagedList<AviationMedicine> GetAviationMedicineList(string name, int pageIndex, int pageSize);
        AviationMedicine GetAviationMedicineByKey(int transactionNumber);
    }
}
