using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam.PhysicalExamMax
{
    public interface ISkinSurgeryRepository : IRepository<SkinSurgery>
    {
        SkinSurgery GetSkinSurgeryByYear(int aircrewID, int year);

        SkinSurgery GetSkinSurgeryByKey(int transactionNumber);
    }
}
