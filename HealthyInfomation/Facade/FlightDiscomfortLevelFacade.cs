using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;

namespace HealthyInfomation.Facade
{
    public class FlightDiscomfortLevelFacade : RestClientWrapper
    {
        public FlightDiscomfortLevelFacade(WindowBase windowBase)
            : base("FlightDiscomfortLevelWCF", "PhysicalExam", windowBase)
        {

        }

        public async Task<BaseResponse> CreateFlightDiscomfortLevel(FlightDiscomfortLevelRequest request)
        {
            return await this.PostAsync<FlightDiscomfortLevelRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateFlightDiscomfortLevel(FlightDiscomfortLevelRequest request)
        {
            return await this.PutAsync<FlightDiscomfortLevelRequest, BaseResponse>("update", request);
        }

        public async Task<List<FlightDiscomfortLevelEntity>> GetFlightDiscomfortLevelByYear(int year)
        {
            return await this.GetAsync<List<FlightDiscomfortLevelEntity>>(string.Format("get/year/{0}", year));
        }

        public async void DeleteFlightDiscomfortLevel(int year)
        {
            await this.DeleteAsync<string>(string.Format("delete/{0}", year));
        }
    }
}
