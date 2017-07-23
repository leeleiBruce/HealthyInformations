using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Infrastructrue.Paged;
using HealthyInformation.Model;
using HealthyInformation.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public class AviationMedicineService : BaseService<AviationMedicine>, IAviationMedicineService
    {
        IAviationMedicineRepository aviationMedicineRepository;
        public AviationMedicineService()
        {
            aviationMedicineRepository = new AviationMedicineRepository(this.dbContext);
        }

        public AviationMedicineResponse GetAviationMedicineList(string name, int pageIndex, int pageSize)
        {
            IPagedList<AviationMedicine> aviationMedicines = aviationMedicineRepository.GetAviationMedicineList(name, pageIndex, pageSize);
            return new AviationMedicineResponse
            {
                TotalCount = aviationMedicines.Count(),
                AviationMedicineList = aviationMedicines.ToList()
            };
        }

        public BaseResponse CreateAviationMedicine(AviationMedicineRequest request)
        {
            var aviationMedicine = new AviationMedicine
            {
                Name = request.Name,
                Sex = request.Sex,
                ContactPhone = request.ContactPhone,
                EmploymentDate = request.EmploymentDate.GetValueOrDefault(DateTime.Now),
                GraduationSchool = request.GraduationSchool,
                Professional = request.Professional,
                Qualifications = request.Qualifications,
                LastEditUser = request.ActionUserID,
                LastEditDate = DateTime.Now,
                InUser = request.ActionUserID,
                InDate = DateTime.Now
            };

            this.aviationMedicineRepository.Create(aviationMedicine);
            this.unitOfWork.Commit();

            return this.BuildSuccessResponse();
        }

        public BaseResponse UpdateAviationMedicine(AviationMedicineRequest request)
        {
            var aviationMedicine = this.aviationMedicineRepository.GetAviationMedicineByKey(request.TransactionNumber);
            if (aviationMedicine == null)
            {
                return this.BuildErrorResponse("AM_002"); //does not exist
            }

            aviationMedicine.TransactionNumber = request.TransactionNumber;
            aviationMedicine.Sex = request.Sex;
            aviationMedicine.Name = request.Name;
            aviationMedicine.ContactPhone = request.ContactPhone;
            aviationMedicine.EmploymentDate = request.EmploymentDate.Value;
            aviationMedicine.GraduationSchool = request.GraduationSchool;
            aviationMedicine.Professional = request.Professional;
            aviationMedicine.Qualifications = request.Qualifications;
            aviationMedicine.LastEditUser = request.ActionUserID;
            aviationMedicine.LastEditDate = DateTime.Now;

            this.aviationMedicineRepository.Update(aviationMedicine);
            this.unitOfWork.Commit();

            return this.BuildSuccessResponse();
        }

        public BaseResponse DeleteAviationMedicine(int transactionNumber)
        {
            var commonDisease = this.aviationMedicineRepository.GetAviationMedicineByKey(transactionNumber);
            if (commonDisease != null)
            {
                this.aviationMedicineRepository.Remove(commonDisease);
                this.unitOfWork.Commit();
            }

            return this.BuildSuccessResponse();
        }
    }
}
