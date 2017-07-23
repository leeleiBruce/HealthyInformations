using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface IOralCavityRepository : IRepository<OralCavity>
    {
        OralCavity GetOralCavityByYear(int aircrewID, int year);

        OralCavity GetOralCavityByKey(int transactionNumber);
    }
}
