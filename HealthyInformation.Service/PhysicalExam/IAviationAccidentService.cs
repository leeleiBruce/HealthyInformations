using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IAviationAccidentService : IService<AviationAccident>
    {
        BaseResponse CreateAviationAccident(AviationAccidentRequest request);
        BaseResponse UpdateAviationAccident(AviationAccidentRequest request);
        List<AviationAccident> GetAviationAccidentByYear(int year);
        void DeleteAviationAccident(int key);
    }
}
