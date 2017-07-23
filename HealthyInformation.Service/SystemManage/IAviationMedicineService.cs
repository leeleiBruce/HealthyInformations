using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public interface IAviationMedicineService : IService<AviationMedicine>
    {
        AviationMedicineResponse GetAviationMedicineList(string name, int pageIndex, int pageSize);
        BaseResponse CreateAviationMedicine(AviationMedicineRequest request);
        BaseResponse UpdateAviationMedicine(AviationMedicineRequest request);
        BaseResponse DeleteAviationMedicine(int transactionNumber);
    }
}
