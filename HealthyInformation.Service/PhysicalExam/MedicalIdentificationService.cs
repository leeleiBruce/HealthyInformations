using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository.PhysicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public class MedicalIdentificationService : BaseService<MedicalIdentification>, IMedicalIdentificationService
    {
        IMedicalIdentificationRepository repository;
        public MedicalIdentificationService()
        {
            this.repository = new MedicalIdentificationRepository(this.dbContext);
        }

        public BaseResponse CreateMedicalIdentification(MedicalIdentificationRequest request)
        {
            var entity = new MedicalIdentification
            {
                AircrewID = request.AircrewID,
                Content = request.Content,
                AviationMedicineID = request.AviationMedicineID,
                RecordDate = request.RecordDate.GetValueOrDefault(DateTime.Now),
                InUser = request.ActionUserID,
                InDate = DateTime.Now,
                LastEditDate = DateTime.Now,
                LastEditUser = request.ActionUserID
            };
            return this.Create(entity);
        }

        public BaseResponse UpdateMedicalIdentification(MedicalIdentificationRequest request)
        {
            var entity = this.repository.GetMedicalIdentificationByKey(request.TransactionNumber);
            if (entity == null) return this.BuildSuccessResponse();

            entity.AircrewID = request.AircrewID;
            entity.Content = request.Content;
            entity.AviationMedicineID = request.AviationMedicineID;
            entity.RecordDate = request.RecordDate.GetValueOrDefault(DateTime.Now);
            entity.LastEditDate = DateTime.Now;
            entity.LastEditUser = request.ActionUserID;

            return this.Update(entity);
        }

        public BaseResponse RemoveMedicalIdentification(int transactionNumber)
        {
            var entity = this.repository.GetMedicalIdentificationByKey(transactionNumber);
            if (entity == null) return this.BuildSuccessResponse();

            return this.Remove(entity);
        }

        public MedicalIdentification GetMedicalIdentification(int aircrewID)
        {
            return this.repository.GetMedicalIdentification(aircrewID);
        }

        public MedicalIdentification GetMedicalIdentificationByYear(int aircrewID, int year)
        {
            return this.repository.GetMedicalIdentificationByYear(aircrewID, year);
        }
    }
}
