using HealthyInfomation.Windows;
using HealthyInformation.ClientEntity;
using HealthyInformation.ClientEntity.SystemManage.Entity;
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
    public class SanatoriumFacade : RestClientWrapper
    {
        public SanatoriumFacade(WindowBase windowBase)
            : base("SanatoriumService", "SystemManage", windowBase)
        {
        }

        public async Task<SanatoriumResponse> GetSanatoriumList(string diseaseName, int pageIndex, int pageSize)
        {
            string url = string.Format("get?name={0}&pageIndex={1}&pageSize={2}", Uri.EscapeDataString(diseaseName ?? string.Empty), pageIndex, pageSize);
            return await this.GetAsync<SanatoriumResponse>(url);
        }

        public async Task<BaseResponse> CreateSanatorium(SanatoriumRequest request)
        {
            return await this.PostAsync<SanatoriumRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateSanatorium(SanatoriumRequest request)
        {
            return await this.PutAsync<SanatoriumRequest, BaseResponse>("update", request);
        }

        public async Task<BaseResponse> DeleteSanatorium(int transactionNumber)
        {
            return await this.DeleteAsync<BaseResponse>(string.Format("delete/{0}", transactionNumber.ToString()));
        }

        public async Task<SanatoriumEntity> GetSanatoriumSingle(int transactionNumber)
        {
            return await this.GetAsync<SanatoriumEntity>(string.Format("single/get?transactionNumber={0}", transactionNumber));
        }
    }
}
