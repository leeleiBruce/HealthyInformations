﻿using HealthyInformation.Entity;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using HealthyInformation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Service.PhysicalExam
{
    public interface IMedicalTreatmentService : IService<MedicalTreatment>
    {
        BaseResponse CreateMedicalTreatment(MedicalTreatmentRequest request);

        BaseResponse UpdateMedicalTreatment(MedicalTreatmentRequest request);

        List<MedicalTreatment> GetMedicalTreatmentByYear(int year);

        void DeleteMedicalTreatment(int key);

        List<UP_GetMedicalTreatAlarmInfo_Result> GetMedicalTreatmentByAlarmDate();
    }
}
