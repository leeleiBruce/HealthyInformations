using HealthyInformation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Repository.PhysicalExam
{
    public interface IMedicalIdentificationRepository
    {
        MedicalIdentification GetMedicalIdentification(int aviationMedicineID);
        MedicalIdentification GetMedicalIdentificationByKey(int transactionNumber);
        MedicalIdentification GetMedicalIdentificationByYear(int aircrewID, int year);
        List<UP_GetPhysicalExamAlarmInfo_Result> GetPhysicalAlarmList();
    }
}
