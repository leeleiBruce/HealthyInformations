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
    public class AviationAccidentService : BaseService<AviationAccident>, IAviationAccidentService
    {
        IAviationAccidentRepository repository;
        public AviationAccidentService()
        {
            repository = new AviationAccidentRepository(this.dbContext);
        }

        public BaseResponse CreateAviationAccident(AviationAccidentRequest request)
        {
            var model = AutoMapper.Mapper.Map<AviationAccident>(request);
            model.InDate = DateTime.Now;
            model.LastEditDate = DateTime.Now;
            model.LastEditUser = request.ActionUserID;

            try
            {
                this.Create(model);
            }
            catch (Exception ex)
            {
                return this.BuildExceptionResponse(ex);
            }


            return this.BuildSuccessResponse();
        }

        public BaseResponse UpdateAviationAccident(AviationAccidentRequest request)
        {
            var aviationAccident = this.repository.GetAviationAccidentByKey(request.TransactionNumber);
            aviationAccident.Condition = request.Condition;
            aviationAccident.FlyDate = request.FlyDate.Value;
            aviationAccident.FlySubject = request.FlySubject;
            aviationAccident.Nature = request.Nature;
            aviationAccident.Reason = request.Reason;
            aviationAccident.Suggestion = request.Suggestion;
            aviationAccident.LastEditDate = DateTime.Now;
            aviationAccident.LastEditUser = request.ActionUserID;

            return this.Update(aviationAccident);
        }

        public List<AviationAccident> GetAviationAccidentByYear(int year)
        {
            return repository.GetAviationAccidentByYear(year);
        }

        public void DeleteAviationAccident(int key)
        {
            var aviationAccident = repository.GetAviationAccidentByKey(key);
            if (aviationAccident == null) return;

            this.Remove(aviationAccident);
        }
    }
}
