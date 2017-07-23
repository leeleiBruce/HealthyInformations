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
    public class AviationMedicineFacade : RestClientWrapper
    {
        public AviationMedicineFacade(WindowBase windowBase)
            : base("AviationMedicineService", "SystemManage", windowBase)
        {
        }

        public async Task<AviationMedicineResponse> GetAviationMedicineList(string diseaseName, int pageIndex, int pageSize)
        {
            string url = string.Format("get?name={0}&pageIndex={1}&pageSize={2}", Uri.EscapeDataString(diseaseName ?? string.Empty), pageIndex, pageSize);
            return await this.GetAsync<AviationMedicineResponse>(url);
        }

        public async Task<BaseResponse> CreateAviationMedicine(AviationMedicineRequest request)
        {
            return await this.PostAsync<AviationMedicineRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateAviationMedicine(AviationMedicineRequest request)
        {
            return await this.PutAsync<AviationMedicineRequest, BaseResponse>("update", request);
        }

        public async Task<BaseResponse> RemoveAviationMedicine(int transactionNumber)
        {
            return await this.DeleteAsync<BaseResponse>(string.Format("delete/{0}", transactionNumber.ToString()));
        }
    }
}
