using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
