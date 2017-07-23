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
    public class FlightDiscomfortableLevelService : BaseService<FlightDiscomfortLevel>, IFlightDiscomfortableLevelService
    {
        IFlightDiscomfortableLevelRepository repository;
        public FlightDiscomfortableLevelService()
        {
            repository = new FlightDiscomfortableLevelRepository(this.dbContext);
        }

        public BaseResponse CreateFlightDiscomfortableLevel(FlightDiscomfortLevelRequest request)
        {
            var model = AutoMapper.Mapper.Map<FlightDiscomfortLevel>(request);
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
