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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MedicalIdentification”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MedicalIdentification.svc 或 MedicalIdentification.svc.cs，然后开始调试。
    public class MedicalIdentificationWCF : IMedicalIdentificationWCF
    {
        IMedicalIdentificationService medicalIdentificationService = new MedicalIdentificationService();
        public BaseResponse CreateMedicalIdentification(MedicalIdentificationRequest request)
        {
            return medicalIdentificationService.CreateMedicalIdentification(request);
        }

        public BaseResponse UpdateMedicalIdentification(MedicalIdentificationRequest request)
        {
            return medicalIdentificationService.UpdateMedicalIdentification(request);
        }

        public BaseResponse RemoveMedicalIdentification(string transactionNumber)
        {
            return medicalIdentificationService.RemoveMedicalIdentification(int.Parse(transactionNumber));
        }

        public MedicalIdentification GetMedicalIdentification(int aircrewID)
        {
            return medicalIdentificationService.GetMedicalIdentification(aircrewID);
        }

        public MedicalIdentification GetMedicalIdentificationByYear(string aircrewID, string year)
        {
            return medicalIdentificationService.GetMedicalIdentificationByYear(int.Parse(aircrewID), int.Parse(year));
        }
    }
}
