using HealthyInfomation.Windows;
using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.ClientEntity.SystemManage.Response;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.ClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInfomation.Facade
{
    public class CommonDiseaseFacade : RestClientWrapper
    {
        public CommonDiseaseFacade(WindowBase windowBase)
            : base("CommonDiseaseService", "SystemManage", windowBase)
        {

        }

        public async Task<CommonDiseaseResponse> GetCommonDiseaseList(string diseaseName, int pageIndex, int pageSize)
        {
            string url = string.Format("get?name={0}&pageIndex={1}&pageSize={2}", Uri.EscapeDataString(diseaseName ?? string.Empty), pageIndex, pageSize);
            return await this.GetAsync<CommonDiseaseResponse>(url);
        }

        public async Task<BaseResponse> CreateCommonDisease(CommonDiseaseRequest request)
        {
            return await this.PostAsync<CommonDiseaseRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateCommonDisease(CommonDiseaseRequest request)
        {
            return await this.PutAsync<CommonDiseaseRequest, BaseResponse>("update", request);
        }

        public async Task<BaseResponse> RemoveCommonDisease(int transactionNumber)
        {
            return await this.DeleteAsync<BaseResponse>(string.Format("delete/{0}", transactionNumber.ToString()));
        }
    }
}
