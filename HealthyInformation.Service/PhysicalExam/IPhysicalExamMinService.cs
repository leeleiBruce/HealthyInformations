using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IPhysicalExamMinService
    {
        PhysicalExamMinRecord GetPhysicalExamMin(int year);

        BaseResponse CreatePhysicalExamMin(PhysicalExamMinRecordRequest request);

        BaseResponse UpdatePhysicalExamMin(PhysicalExamMinRecordRequest request);

        BaseResponse RemovePhysicalExamMin(BaseRemoveRequest request);

        BaseResponse RemovePhysicalExamMinByKey(string transactionID);
    }
}
