using AutoMapper;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;
using HealthyInformation.ClientEntity.PhysicalExam.Request;
using HealthyInformation.ClientEntity.PhysicalExam.ViewModel;
using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.ClientEntity.SystemManage.Request;
using HealthyInformation.ClientEntity.SystemManage.ViewModel;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HealthyInfomation
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitMapperCollection();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        private void InitMapperCollection()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CommonDiseaseEntity, CommonDiseaseModel>();
                cfg.CreateMap<AviationMedicineEntity, AviationMedicineModel>()
                    .ForMember(dest => dest.ContactTel, mo => mo.MapFrom(m => m.ContactPhone))
                    .ForMember(dest => dest.PersonQualification, mo => mo.MapFrom(m => m.Qualifications))
                    .ForMember(dest => dest.WorkDate, mo => mo.MapFrom(m => m.EmploymentDate));
                cfg.CreateMap<SanatoriumEntity, SanatoriumModel>();

                cfg.CreateMap<AircrewModel, AircrewEntity>();
                cfg.CreateMap<AircrewEntity, AircrewModel>();
                cfg.CreateMap<MedicalTreatmentModel, MedicalTreatmentRequest>()
                    .ForMember(dest => dest.NeedObservation, mo => mo.MapFrom(m => m.NeedObservation ? "1" : "0"));
                cfg.CreateMap<FlightDiscomfortLevelModel, FlightDiscomfortLevelRequest>();
                cfg.CreateMap<AviationAccidentModel, AviationAccidentRequest>();
                cfg.CreateMap<ENTSectionModel, ENTSectionRequest>();
                cfg.CreateMap<PhthalmologyModel, PhthalmologyRequest>();
                cfg.CreateMap<NeuropsychiatryModel, NeuropsychiatryRequest>();
                cfg.CreateMap<InternalMedicineModel, InternalMedicineRequest>();
                cfg.CreateMap<SkinSurgeryModel, SkinSurgeryRequest>();
                cfg.CreateMap<SupplementaryExamModel, SupplementaryExamRequest>();
                cfg.CreateMap<ConclusionPhysicalModel, ConclusionPhysicalRequest>();
                cfg.CreateMap<MedicalIdentificationEntity, MedicalIdentificationModel>();
                cfg.CreateMap<SkinSurgeryEntity, SkinSurgeryModel>();
                cfg.CreateMap<ConclusionsphysicalexamEntity, ConclusionPhysicalModel>();
                cfg.CreateMap<ENTSectionEntity, ENTSectionModel>();
                cfg.CreateMap<InternalMedicineEntity, InternalMedicineModel>();
                cfg.CreateMap<NeuropsychiatryEntity, NeuropsychiatryModel>();
                cfg.CreateMap<PhthalmologyEntity, PhthalmologyModel>();
                cfg.CreateMap<OralCavityEntity, OralCavityModel>();
                cfg.CreateMap<SupplementaryExamEntity, SupplementaryExamModel>();
            });
        }
    }
}