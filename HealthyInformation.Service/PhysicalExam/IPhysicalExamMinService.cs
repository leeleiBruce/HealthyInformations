using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IPhysicalExamMinService
    {
        BaseResponse CreatePhysicalExamMin(PhysicalExamMinRecordRequest request);
        
        BaseResponse UpdatePhysicalExamMin(PhysicalExamMinRecordRequest request);

        BaseResponse RemovePhysicalExamMin(BaseRemoveRequest request);
    }
}
