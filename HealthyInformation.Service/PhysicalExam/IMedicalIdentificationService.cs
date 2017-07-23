using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IMedicalIdentificationService : IService<MedicalIdentification>
    {
        BaseResponse CreateMedicalIdentification(MedicalIdentificationRequest medicalIdentification);

        BaseResponse UpdateMedicalIdentification(MedicalIdentificationRequest medicalIdentification);

        BaseResponse RemoveMedicalIdentification(int transactionNumber);

        MedicalIdentification GetMedicalIdentification(int aircrewID);

        MedicalIdentification GetMedicalIdentificationByYear(int aircrewID,int year);
    }
}
