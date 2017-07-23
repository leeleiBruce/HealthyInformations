using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam;
using HealthyInformation.Service.PhysicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthyInformation.WCFService.Services.PhysicalExam
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PhysicalExamMinWCF”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PhysicalExamMinWCF.svc 或 PhysicalExamMinWCF.svc.cs，然后开始调试。
    public class PhysicalExamMinWCF : IPhysicalExamMinWCF
    {
        IPhysicalExamMinService service = new PhysicalExamMinService();
        public BaseResponse CreatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            return service.CreatePhysicalExamMin(request);
        }

        public BaseResponse UpdatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            return service.UpdatePhysicalExamMin(request);
        }

        public BaseResponse RemovePhysicalExamMin(BaseRemoveRequest request)
        {
            return service.RemovePhysicalExamMin(request);
        }
    }
}
