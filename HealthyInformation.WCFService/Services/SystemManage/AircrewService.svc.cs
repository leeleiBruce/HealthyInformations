using HealthyInformation.Entity;
using HealthyInformation.Entity.SystemManage.Request;
using HealthyInformation.Entity.SystemManage.Response;
using HealthyInformation.Model;
using HealthyInformation.Service.SystemManage;
using System;
using System.Collections.Generic;

namespace HealthyInformation.WCFService.Services.SystemManage
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AircrewService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AircrewService.svc 或 AircrewService.svc.cs，然后开始调试。
    public class AircrewService : IAircrewService
    {
        IAircrewManageService aircrewManageService = new AircrewManageService();
        IFlightRecordService flightRecordService = new FlightRecordService();

        public AircrewResponse GetAircrewList(string name, DateTime startDate, DateTime endDate, int pageIndex, int pageSize)
        {
            return aircrewManageService.GetAircrewList(name, startDate, endDate, pageIndex, pageSize);
        }

        public BaseResponse CreateAircrew(AircrewRequest request)
        {
            var response= aircrewManageService.Create(request.Aircrew);
            if (request.FlightRecordList != null && request.FlightRecordList.Count > 0)
            {
                foreach (var record in request.FlightRecordList)
                {
                    record.AircrewID = request.Aircrew.TransactionNumber;
                    record.InDate = DateTime.Now;
                    record.InUser = request.ActionUserID;
                    record.LastEditDate = DateTime.Now;
                    record.LastEditUser = request.ActionUserID;

                    aircrewManageService.CreateFlightRecord(record);
                }
            }

            return response;
        }

        public BaseResponse UpdateAircrew(AircrewRequest request)
        {
            var response = aircrewManageService.Update(request.Aircrew);
            var flightRecordOrgList = flightRecordService.GetFlightRecordList(request.Aircrew.TransactionNumber);

            if (request.FlightRecordList != null && request.FlightRecordList.Count > 0)
            {
                foreach (var flightRecordOrg in flightRecordOrgList)
                {
                    flightRecordService.Remove(flightRecordOrg);
                }

                foreach (var record in request.FlightRecordList)
                {
                    record.AircrewID = request.Aircrew.TransactionNumber;
                    record.InDate = DateTime.Now;
                    record.InUser = request.ActionUserID;
                    record.LastEditDate = DateTime.Now;
                    record.LastEditUser = request.ActionUserID;

                    aircrewManageService.CreateFlightRecord(record);
                }
            }

            return response;
        }

        public BaseResponse UpdateAircrewPhoto(AircrewPhotoRequest request)
        {
            return aircrewManageService.UpdatePhoto(request);
        }

        public BaseResponse RemoveAircrew(string transactionNumber)
        {
            return aircrewManageService.DeleteAircrew(int.Parse(transactionNumber));
        }

        public List<FlightRecord> GetFlightRecord(string aircrewID)
        {
            return flightRecordService.GetFlightRecordList(int.Parse(aircrewID));
        }

        public Aircrew GetAircrewByKey(string transactionNumber)
        {
            return aircrewManageService.GetAircrewByKey(transactionNumber);
        }
    }
}
