using HealthyInformation.ClientEntity.SystemManage.Response;
using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“SanatoriumService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 SanatoriumService.svc 或 SanatoriumService.svc.cs，然后开始调试。
    public class SanatoriumService : ISanatoriumService
    {
        ISanatoriumManageService sanatoriumManageService = new SanatoriumManageService();
        public SanatoriumResponse GetSanatoriumList(string name, int pageIndex, int pageSize)
        {
            return sanatoriumManageService.GetSanatoriumList(name, pageIndex, pageSize);
        }

        public BaseResponse CreateSanatorium(SanatoriumRequest request)
        {
            return sanatoriumManageService.CreateSanatorium(request);
        }

        public BaseResponse UpdateSanatorium(SanatoriumRequest request)
        {
            return sanatoriumManageService.UpdateSanatorium(request);
        }

        public BaseResponse RemoveSanatorium(string transactionNumber)
        {
            return sanatoriumManageService.RemoveSanatorium(int.Parse(transactionNumber));
        }

        public Sanatorium GetSanatoriumByKey(string transactionNumber)
        {
            return sanatoriumManageService.GetSanatoriumByKey(int.Parse(transactionNumber));
        }
    }
}
