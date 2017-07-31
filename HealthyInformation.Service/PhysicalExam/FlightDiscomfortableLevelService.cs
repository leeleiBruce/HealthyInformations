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

        public BaseResponse UpdateFlightDiscomfortableLevel(FlightDiscomfortLevelRequest request)
        {
            var flightDiscomfortable = this.repository.GetFlightDiscomfortLevelByKey(request.TransactionNumber);
            flightDiscomfortable.Complained = request.Complained;
            flightDiscomfortable.Examination = request.Examination;
            flightDiscomfortable.FlyDate = request.FlyDate;
            flightDiscomfortable.FlyerType = request.FlyerType;
            flightDiscomfortable.FlyHeight = request.FlyHeight;
            flightDiscomfortable.FlySpeed = request.FlySpeed;
            flightDiscomfortable.FlySubject = request.FlySubject;
            flightDiscomfortable.FlyTotalTime = request.FlyTotalTime;
            flightDiscomfortable.LastEditDate = DateTime.Now;
            flightDiscomfortable.LastEditUser = request.ActionUserID;
            flightDiscomfortable.Measure = request.Measure;
            flightDiscomfortable.WeatherCondition = request.WeatherCondition;

            return this.Update(flightDiscomfortable);
        }

        public List<FlightDiscomfortLevel> GetFlightDiscomfortableLevelByYear(int year)
        {
            return this.repository.GetFlightDiscomfortLevelByYear(year);
        }

        public void DeleteFlightDiscomfortableLevel(int key)
        {
            var flightComfortable = this.repository.GetFlightDiscomfortLevelByKey(key);
            if (flightComfortable == null) return;

            this.Remove(flightComfortable);
        }
    }
}
