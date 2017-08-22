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
    public class PhysicalExamMinFacade : RestClientWrapper
    {
        public PhysicalExamMinFacade(WindowBase windowBase)
            : base("PhysicalExamMinWCF", "PhysicalExam", windowBase)
        {
        }

        public async Task<PhysicalExamMinRecord> GetPhysicalExamMinByYear(int year)
        {
            return await this.GetAsync<PhysicalExamMinRecord>(string.Format("get/year/{0}", year));
        }

        public async Task<BaseResponse> CreatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            return await this.PostAsync<PhysicalExamMinRecordRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            return await this.PutAsync<PhysicalExamMinRecordRequest, BaseResponse>("update", request);
        }

        public async Task<BaseResponse> RemovePhysicalExamMinByKey(int transactionNumber)
        {
            return await this.DeleteAsync<BaseResponse>(string.Format("delete/single/{0}", transactionNumber));
        }
    }
}
