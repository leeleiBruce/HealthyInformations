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
                this.Update(medicalTreatment);
            }
            catch (Exception ex)
            {
                return this.BuildExceptionResponse(ex);
            }

            return this.BuildSuccessResponse();
        }

        public List<MedicalTreatment> GetMedicalTreatmentByYear(int year)
        {
            return this.medicalTreatmentRepository.GetMedicalTreatmentByYear(year);
        }

        public void DeleteMedicalTreatment(int key)
        {
            var medicalTreatment = medicalTreatmentRepository.GetMedicalTreatmentByKey(key);
            if(medicalTreatment!=null)
            {
                this.Remove(medicalTreatment);
            }
        }
    }
}
