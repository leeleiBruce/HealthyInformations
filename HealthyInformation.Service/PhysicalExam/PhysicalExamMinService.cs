using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam;
using HealthyInformation.Model;
using HealthyInformation.Repository.PhysicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public class PhysicalExamMinService : BaseService<PhysicalExamMinRecord>, IPhysicalExamMinService
    {
        IPhysicalExamMinRepository repository;
        public PhysicalExamMinService()
        {
            this.repository = new PhysicalExamMinRepository(this.dbContext);
        }

        public BaseResponse CreatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            var physicalExamMinRecord = new PhysicalExamMinRecord
            {
                AircrewID = request.AircrewID,
                BloodPressure = request.BloodPressure,
                Conclusion = request.Conclusion,
                AviationMedicineID = request.AviationMedicineID,
                Pulse = request.Pulse,
                VisionLeft = request.VisionLeft,
                VisionRight = request.VisionRight,
                Weight = request.Weight,
                RecordDate = request.RecordDate,
                InDate = DateTime.Now,
                InUser = request.ActionUserID,
                LastEditDate = DateTime.Now,
                LastEditUser = request.ActionUserID
            };

            this.Create(physicalExamMinRecord);
            return this.BuildSuccessResponse();
        }

        public BaseResponse UpdatePhysicalExamMin(PhysicalExamMinRecordRequest request)
        {
            var physicalExamMinRecord = this.repository.GetPhysicalExamMinRecordByKey(request.TransactionNumber);
            if (physicalExamMinRecord != null)
            {
                physicalExamMinRecord.AircrewID = request.AircrewID;
                physicalExamMinRecord.BloodPressure = request.BloodPressure;
                physicalExamMinRecord.Conclusion = request.Conclusion;
                physicalExamMinRecord.AviationMedicineID = request.AviationMedicineID;
                physicalExamMinRecord.Pulse = request.Pulse;
                physicalExamMinRecord.VisionLeft = request.VisionLeft;
                physicalExamMinRecord.VisionRight = request.VisionRight;
                physicalExamMinRecord.Weight = request.Weight;
                physicalExamMinRecord.RecordDate = request.RecordDate;
                physicalExamMinRecord.LastEditDate = DateTime.Now;
                physicalExamMinRecord.LastEditUser = request.ActionUserID;

                this.Update(physicalExamMinRecord);
            }

            return this.BuildSuccessResponse();
        }

        public BaseResponse RemovePhysicalExamMin(BaseRemoveRequest request)
        {
            foreach (var key in request.KeyList)
            {
                var physicalExamMinRecord = this.repository.GetPhysicalExamMinRecordByKey(key);
                this.RemoveWithoutCommit(physicalExamMinRecord);
            }

            this.unitOfWork.Commit();
            return this.BuildSuccessResponse();
        }
    }
}
