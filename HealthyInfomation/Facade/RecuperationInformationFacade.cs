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
    public class RecuperationInformationFacade : RestClientWrapper
    {
        public RecuperationInformationFacade(WindowBase windowBase)
            : base("RecuperationInformationWCF", "SystemManage", windowBase)
        {
        }

        public async Task<List<UP_GetRecuperationPlan_Result>> GetRecuperationPlanList(int sanatoriumID, DateTime? startDate, DateTime? endDate)
        {
            return await this.GetAsync<List<UP_GetRecuperationPlan_Result>>(string.Format("get?sanatoriumID={0}&startDate={1}&endDate={2}", sanatoriumID, startDate, endDate));
        }

        public async Task<BaseResponse> CreateRecuperationInformation(RecuperationInformationRequest request)
        {
            return await this.PostAsync<RecuperationInformationRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateRecuperationInformation(RecuperationInformationRequest request)
        {
            return await this.PutAsync<RecuperationInformationRequest, BaseResponse>("update", request);
        }
          
        public async Task<RecuperationInformationResponse> GetRecuperationInformation(int key)
        {
            return await this.GetAsync<RecuperationInformationResponse>(string.Format("report/get/{0}", key));
        }

        public async Task<string> RemoveRecuperationInformation(int key)
        {
            return await this.DeleteAsync<string>(string.Format("delete/{0}", key));
        }

        public async Task<RecuperationInformationEntity> GetRecuperationDetail(int key)
        {
            return await this.GetAsync<RecuperationInformationEntity>(string.Format("detail/get/{0}", key));
        }
    }
}
