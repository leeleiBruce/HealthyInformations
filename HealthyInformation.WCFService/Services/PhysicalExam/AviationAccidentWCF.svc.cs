using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using HealthyInformation.Service.PhysicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthyInformation.WCFService.Services.PhysicalExam
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AviationAccidentWCF”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AviationAccidentWCF.svc 或 AviationAccidentWCF.svc.cs，然后开始调试。
    public class AviationAccidentWCF : IAviationAccidentWCF
    {
        IAviationAccidentService service = new AviationAccidentService();
        public BaseResponse CreateAviationAccident(AviationAccidentRequest request)
        {
            return service.CreateAviationAccident(request);
        }

        public BaseResponse UpdateAviationAccident(AviationAccidentRequest request)
        {
            return service.UpdateAviationAccident(request);
        }

        public List<AviationAccident> GetAviationAccidentByYear(string year)
        {
            return service.GetAviationAccidentByYear(int.Parse(year));
        }

        public void DeleteAviationAccident(string key)
        {
           service.DeleteAviationAccident(int.Parse(key));
        }
    }
}
