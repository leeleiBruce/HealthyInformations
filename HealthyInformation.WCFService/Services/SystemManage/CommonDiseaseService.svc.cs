using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using HealthyInformation.Service.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CommonDiseaseService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CommonDiseaseService.svc 或 CommonDiseaseService.svc.cs，然后开始调试。
    public class CommonDiseaseService : ICommonDiseaseService
    {
        IDiseaseService diseaseService = new DiseaseService();

        public CommonDiseaseResponse GetCommonDiseaseList(string name, int pageIndex, int pageSize)
        {
            return this.diseaseService.GetCommonDisease(name, pageIndex, pageSize);
        }

        public BaseResponse CreateCommonDisease(CommonDiseaseRequest request)
        {
            return this.diseaseService.CreateCommonDisease(request);
        }

        public BaseResponse UpdateCommonDisease(CommonDiseaseRequest request)
        {
            return this.diseaseService.UpdateCommonDisease(request);
        }

        public BaseResponse RemoveCommonDisease(string transactionNumber)
        {
            return this.diseaseService.RemoveCommonDisease(int.Parse(transactionNumber));
        }
    }
}
