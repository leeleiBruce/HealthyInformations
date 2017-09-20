using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using HealthyInformation.Repository.SystemManage;
using System;
using System.Linq;
using System.Text;

namespace HealthyInformation.Service.SystemManage
{
    public class AircrewManageService : BaseService<Aircrew>, IAircrewManageService
    {
        IAircrewRepository aircrewRepository;
        IFlightRecordRepository flightRecordRepository;
        public AircrewManageService()
        {
            aircrewRepository = new AircrewRepository(this.dbContext);
            flightRecordRepository = new FlightRecordRepository(this.dbContext);
        }

        public AircrewResponse GetAircrewList(string name, DateTime? startDate, DateTime? endDate, int pageIndex, int pageSize)
        {
            var result = aircrewRepository.GetAircrewList(name, startDate, endDate, pageIndex, pageSize);
            return new AircrewResponse
            {
                TotalCount = result.TotalCount,
                AircrewList = result.ToList()
            };
        }

        public BaseResponse UpdatePhoto(AircrewPhotoRequest request)
        {
            var aircrew = aircrewRepository.GetAircrewByKey(request.TransactionNumber);
            aircrew.Photo = request.PhotoBinary;
            aircrew.LastEditDate = DateTime.Now;
            aircrew.LastEditUser = request.ActionUserID;

            return this.Update(aircrew);
        }

        public BaseResponse DeleteAircrew(int transactionNumber)
        {
            var aircrew = this.aircrewRepository.GetAircrewByKey(transactionNumber);
            if (aircrew != null)
            {
                this.aircrewRepository.Remove(aircrew);
                this.unitOfWork.Commit();
            }

            return this.BuildSuccessResponse();
        }

        public BaseResponse CreateFlightRecord(FlightRecord request)
        {
            var flightRecord = AutoMapper.Mapper.Map<FlightRecord>(request);
            flightRecordRepository.Create(flightRecord);
            this.unitOfWork.Commit();
            return this.BuildSuccessResponse();
        }

        public Aircrew GetAircrewByKey(string transactionNumber)
        {
            int key = 0;
            int.TryParse(transactionNumber, out key);
            return aircrewRepository.GetAircrewByKey(key);
        }
    }
}
