using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using AutoMapper;
using HealthyInformation.Entity.PhysicalExam.Request;
using HealthyInformation.Model;
using HealthyInformation.Entity.SystemManage.Request;

namespace HealthyInformation.WCFService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            InitMapperCollection();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void InitMapperCollection()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AircrewEntity, Aircrew>();
                cfg.CreateMap<MedicalTreatmentRequest, MedicalTreatment>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID));
                cfg.CreateMap<FlightDiscomfortLevelRequest, FlightDiscomfortLevel>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID));
                cfg.CreateMap<AviationAccidentRequest, AviationAccident>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID));
                cfg.CreateMap<RecuperationInformationRequest, RecuperationInformation>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID));
                cfg.CreateMap<OralCavityRequest, OralCavity>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                    .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                    .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                    .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
                cfg.CreateMap<ENTSectionRequest, ENTSection>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                    .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                    .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                    .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
                cfg.CreateMap<PhthalmologyRequest, Phthalmology>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                   .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
                cfg.CreateMap<NeuropsychiatryRequest, Neuropsychiatry>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                   .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
                cfg.CreateMap<InternalMedicineRequest, InternalMedicine>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                   .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
                cfg.CreateMap<SkinSurgeryRequest, SkinSurgery>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                   .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                   .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
                cfg.CreateMap<SupplementaryExamRequest, SupplementaryExam>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                  .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                  .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                  .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
                cfg.CreateMap<ConclusionPhysicalRequest, ConclusionsPhysical>().ForMember(dest => dest.InUser, mo => mo.MapFrom(m => m.ActionUserID))
                  .ForMember(dest => dest.LastEditUser, mo => mo.MapFrom(m => m.ActionUserID))
                  .ForMember(dest => dest.LastEditDate, mo => mo.MapFrom(m => DateTime.Now))
                  .ForMember(dest => dest.InDate, mo => mo.MapFrom(m => DateTime.Now));
            });
        }
    }
}