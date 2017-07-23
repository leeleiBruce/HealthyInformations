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
    public class AircrewFacade : RestClientWrapper
    {
        public AircrewFacade(WindowBase windowBase)
            : base("AircrewService", "SystemManage", windowBase)
        {
        }

        public async Task<AircrewResponse> GetAircrewList(string name, DateTime? startDate, DateTime? endDate, int pageIndex, int pageSize)
        {
            return await this.GetAsync<AircrewResponse>(string.Format("get?name={0}&startDate={1}&endDate={2}&pageIndex={3}&pageSize={4}", name, startDate, endDate, pageIndex, pageSize));
        }

        public async Task<BaseResponse> CreateAircrew(AircrewRequest request)
        {
            return await this.PostAsync<AircrewRequest, BaseResponse>("create", request);
        }

        public async Task<BaseResponse> UpdateAircrew(AircrewRequest request)
        {
            return await this.PutAsync<AircrewRequest, BaseResponse>("update", request);
        }

        public async Task<BaseResponse> UpdateAircrewPhoto(AircrewPhotoRequest request)
        {
            return await this.PutAsync<AircrewPhotoRequest, BaseResponse>("photoupdate", request);
        }

        public async Task<BaseResponse> RemoveAircrew(int transactionNumber)
        {
            return await this.DeleteAsync<BaseResponse>(string.Format("delete/{0}", transactionNumber.ToString()));
        }

        public async Task<List<FlightRecordEntity>> GetFlightRecord(int aircrewID)
        {
            return await this.GetAsync<List<FlightRecordEntity>>(string.Format("flightrecord/get?aircrewID={0}", aircrewID));
        }
    }
}
