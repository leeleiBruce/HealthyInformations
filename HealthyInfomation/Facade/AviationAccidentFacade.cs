using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;
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

        public async Task<BaseResponse> UpdateAviationAccident(AviationAccidentRequest request)
        {
            return await this.PutAsync<AviationAccidentRequest, BaseResponse>("update", request);
        }

        public async Task<List<AviationAccidentEntity>> GetAviationAccidentByYear(int year)
        {
            return await this.GetAsync<List<AviationAccidentEntity>>(string.Format("get/year/{0}", year));
        }

        public async void DeleteAviationAccident(int year)
        {
            await this.DeleteAsync<string>(string.Format("delete/{0}", year));
        }
    }
}
