using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IMedicalTreatmentService : IService<MedicalTreatment>
    {
        BaseResponse CreateMedicalTreatment(MedicalTreatmentRequest request);
    }
}
