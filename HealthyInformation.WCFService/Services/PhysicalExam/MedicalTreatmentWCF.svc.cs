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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MedicalTreatmentWCF”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MedicalTreatmentWCF.svc 或 MedicalTreatmentWCF.svc.cs，然后开始调试。
    public class MedicalTreatmentWCF : IMedicalTreatmentWCF
    {
        IMedicalTreatmentService medicalTreatmentService = new MedicalTreatmentService();

        public BaseResponse CreateMedicalTreatment(MedicalTreatmentRequest request)
        {
            return medicalTreatmentService.CreateMedicalTreatment(request);
        }

        public BaseResponse UpdateMedicalTreatment(MedicalTreatmentRequest request)
        {
            return medicalTreatmentService.UpdateMedicalTreatment(request);
        }

        public List<MedicalTreatment> GetMedicalTreatmentByYear(string year)
        {
            return medicalTreatmentService.GetMedicalTreatmentByYear(int.Parse(year));
        }

        public List<MedicalTreatment> GetMedicalTreatmentByAlarmDate()
        {
            return medicalTreatmentService.GetMedicalTreatmentByAlarmDate();
        }

        public void DeleteMedicalTreatment(string key)
        {
            medicalTreatmentService.DeleteMedicalTreatment(int.Parse(key));
        }
    }
}
