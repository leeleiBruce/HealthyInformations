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
    public class MedicalTreatmentService : BaseService<MedicalTreatment>, IMedicalTreatmentService
    {
        IMedicalTreatmentRepository medicalTreatmentRepository;
        public MedicalTreatmentService()
        {
            medicalTreatmentRepository = new MedicalTreatmentRepository(this.dbContext);
        }

        public BaseResponse CreateMedicalTreatment(MedicalTreatmentRequest request)
        {
            var medicalTreatment = AutoMapper.Mapper.Map<MedicalTreatmentRequest, MedicalTreatment>(request);
            if (request.NeedObservation == "0")
            {
                medicalTreatment.ObservationStartDate = null;
                medicalTreatment.ObservationEndDate = null;
            }
            medicalTreatment.InDate = DateTime.Now;
            medicalTreatment.InUser = request.ActionUserID;
            medicalTreatment.LastEditDate = DateTime.Now;
            medicalTreatment.LastEditUser = request.ActionUserID;

            try
            {
                this.Create(medicalTreatment);
            }
            catch (Exception ex)
            {
                return this.BuildExceptionResponse(ex);
            }


            return this.BuildSuccessResponse();
        }

        public BaseResponse UpdateMedicalTreatment(MedicalTreatmentRequest request)
        {
            var medicalTreatmentOrg = this.medicalTreatmentRepository.GetMedicalTreatmentByKey(request.TransactionNumber);
            var medicalTreatment = AutoMapper.Mapper.Map<MedicalTreatmentRequest, MedicalTreatment>(request);
            if (request.NeedObservation == "0")
            {
                medicalTreatment.ObservationStartDate = null;
                medicalTreatment.ObservationEndDate = null;
            }
            medicalTreatment.InDate = medicalTreatmentOrg.InDate;
            medicalTreatment.InUser = medicalTreatmentOrg.InUser;
            medicalTreatment.LastEditDate = DateTime.Now;
            medicalTreatment.LastEditUser = request.ActionUserID;
            try
            {
                this.Update(medicalTreatment);
            }
            catch (Exception ex)
            {
                return this.BuildExceptionResponse(ex);
            }


            return this.BuildSuccessResponse();
        }

        public MedicalTreatment GetMedicalTreatmentByYear(int year)
        {
            return this.medicalTreatmentRepository.GetMedicalTreatmentByYear(year);
        }
    }
}
