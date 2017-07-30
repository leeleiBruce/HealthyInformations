using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam
{
    public interface IMedicalTreatmentRepository : IRepository<MedicalTreatment>
    {
        MedicalTreatment GetMedicalTreatmentByKey(int medicalTreatId);

        MedicalTreatment GetMedicalTreatmentByYear(int year);
    }
}
