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
    public class PhysicalExamMinFacade : RestClientWrapper
    {
        public PhysicalExamMinFacade(WindowBase windowBase)
            : base("PhysicalExamMinWCF", "PhysicalExam", windowBase)
        {
        }

        public async Task<BaseResponse> CreatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            return await this.PostAsync<PhysicalExamMinRecordRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            return await this.PutAsync<PhysicalExamMinRecordRequest, BaseResponse>("update", request);
        }

        public async Task<BaseResponse> RemovePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            return await this.PostAsync<PhysicalExamMinRecordRequest, BaseResponse>("delete", request);
        }
    }
}
