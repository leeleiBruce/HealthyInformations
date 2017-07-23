using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.SystemManage
{
    public interface IAircrewManageService : IService<Aircrew>
    {
        AircrewResponse GetAircrewList(string name, DateTime? startDate, DateTime? endDate, int pageIndex, int pageSize);
        BaseResponse UpdatePhoto(AircrewPhotoRequest request);
        BaseResponse DeleteAircrew(int transactionNumber);
        BaseResponse CreateFlightRecord(FlightRecord request);
    }
}
