using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam
{
    public interface IAviationAccidentRepository
    {
        AviationAccident GetAviationAccidentByKey(int key);


        List<AviationAccident> GetAviationAccidentByYear(int year);
    }
}
