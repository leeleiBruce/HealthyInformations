using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IAviationAccidentService
    {
        BaseResponse CreateAviationAccident(AviationAccidentRequest request);
    }
}
