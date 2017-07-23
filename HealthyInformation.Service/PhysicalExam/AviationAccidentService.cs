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
    public class AviationAccidentService : BaseService<AviationAccident>, IAviationAccidentService
    {
        public AviationAccidentService()
        {
 
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
    }
}
