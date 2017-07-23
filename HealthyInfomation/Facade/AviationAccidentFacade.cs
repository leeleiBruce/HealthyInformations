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
    public class AviationAccidentFacade : RestClientWrapper
    {
        public AviationAccidentFacade(WindowBase windowBase)
            : base("AviationAccidentWCF", "PhysicalExam", windowBase)
        {
        }

        public async Task<BaseResponse> CreateAviationAccident(AviationAccidentRequest request)
        {
            return await this.PostAsync<AviationAccidentRequest, BaseResponse>("create", request);
        }
    }
}
