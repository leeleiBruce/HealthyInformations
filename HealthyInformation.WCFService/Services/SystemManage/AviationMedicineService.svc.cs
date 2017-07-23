using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Service1 = HealthyInformation.Service.SystemManage;
namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AviationMedicineService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AviationMedicineService.svc 或 AviationMedicineService.svc.cs，然后开始调试。
    public class AviationMedicineService : IAviationMedicineService
    {
        Service1.IAviationMedicineService aviationMedicineService = new Service1.AviationMedicineService();
        public AviationMedicineResponse GetAviationMedicineList(string name, int pageIndex, int pageSize)
        {
            return aviationMedicineService.GetAviationMedicineList(name, pageIndex, pageSize);
        }

        public BaseResponse CreateAviationMedicine(AviationMedicineRequest request)
        {
            return aviationMedicineService.CreateAviationMedicine(request);
        }

        public BaseResponse UpdateAviationMedicine(AviationMedicineRequest request)
        {
            return aviationMedicineService.UpdateAviationMedicine(request);
        }

        public BaseResponse RemoveAviationMedicine(string transactionNumber)
        {
            return aviationMedicineService.DeleteAviationMedicine(int.Parse(transactionNumber));
        }
    }
}
