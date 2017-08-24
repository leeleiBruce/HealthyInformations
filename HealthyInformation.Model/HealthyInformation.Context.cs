﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthyInformation.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class HealthyInformationEntities : DbContext
    {
        public HealthyInformationEntities()
            : base("name=HealthyInformationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AviationMedicine> AviationMedicine { get; set; }
        public DbSet<CommonDisease> CommonDisease { get; set; }
        public DbSet<FlightDiscomfortLevel> FlightDiscomfortLevel { get; set; }
        public DbSet<FlightRecord> FlightRecord { get; set; }
        public DbSet<MedicalIdentification> MedicalIdentification { get; set; }
        public DbSet<MedicalTreatment> MedicalTreatment { get; set; }
        public DbSet<PhysicalExamMinRecord> PhysicalExamMinRecord { get; set; }
        public DbSet<Sanatorium> Sanatorium { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FlyerType> FlyerType { get; set; }
        public DbSet<AviationAccident> AviationAccident { get; set; }
        public DbSet<RecuperationAccompany> RecuperationAccompany { get; set; }
        public DbSet<RecuperationMember> RecuperationMember { get; set; }
        public DbSet<RecuperationInformation> RecuperationInformation { get; set; }
        public DbSet<OralCavity> OralCavity { get; set; }
        public DbSet<ENTSection> ENTSection { get; set; }
        public DbSet<Phthalmology> Phthalmology { get; set; }
        public DbSet<Neuropsychiatry> Neuropsychiatry { get; set; }
        public DbSet<InternalMedicine> InternalMedicine { get; set; }
        public DbSet<SkinSurgery> SkinSurgery { get; set; }
        public DbSet<SupplementaryExam> SupplementaryExam { get; set; }
        public DbSet<ConclusionsPhysicalExam> ConclusionsPhysical { get; set; }
        public DbSet<Aircrew> Aircrew { get; set; }
    
        public virtual ObjectResult<UP_GetRecuperationPlan_Result1> UP_GetRecuperationPlan(Nullable<int> sanatoriumID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var sanatoriumIDParameter = sanatoriumID.HasValue ?
                new ObjectParameter("SanatoriumID", sanatoriumID) :
                new ObjectParameter("SanatoriumID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetRecuperationPlan_Result1>("UP_GetRecuperationPlan", sanatoriumIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<UP_GetPhysicalExamAlarmInfo_Result> UP_GetPhysicalExamAlarmInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetPhysicalExamAlarmInfo_Result>("UP_GetPhysicalExamAlarmInfo");
        }
    
        public virtual ObjectResult<UP_GetMedicalTreatAlarmInfo_Result> UP_GetMedicalTreatAlarmInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetMedicalTreatAlarmInfo_Result>("UP_GetMedicalTreatAlarmInfo");
        }
    
        public virtual ObjectResult<UP_GetRecuperationCountAnalysis_Result> UP_GetRecuperationCountAnalysis()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetRecuperationCountAnalysis_Result>("UP_GetRecuperationCountAnalysis");
        }
    
        public virtual ObjectResult<UP_GetRecuperationInfoAnalysis_Result> UP_GetRecuperationInfoAnalysis()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetRecuperationInfoAnalysis_Result>("UP_GetRecuperationInfoAnalysis");
        }
    
        public virtual ObjectResult<UP_GetHealthyGradeAnalysis_Result> UP_GetHealthyGradeAnalysis(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetHealthyGradeAnalysis_Result>("UP_GetHealthyGradeAnalysis", yearParameter);
        }
    
        public virtual ObjectResult<UP_GetHealthyGradeDetail_Result> UP_GetHealthyGradeDetail(Nullable<int> grade, Nullable<int> year)
        {
            var gradeParameter = grade.HasValue ?
                new ObjectParameter("Grade", grade) :
                new ObjectParameter("Grade", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetHealthyGradeDetail_Result>("UP_GetHealthyGradeDetail", gradeParameter, yearParameter);
        }
    
        public virtual ObjectResult<UP_GetCommonDiseaseAnalysis_Result> UP_GetCommonDiseaseAnalysis(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetCommonDiseaseAnalysis_Result>("UP_GetCommonDiseaseAnalysis", yearParameter);
        }
    
        public virtual ObjectResult<UP_GetCommonDiseaseDetail_Result> UP_GetCommonDiseaseDetail(Nullable<int> year, Nullable<int> commonDiseaseID)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var commonDiseaseIDParameter = commonDiseaseID.HasValue ?
                new ObjectParameter("CommonDiseaseID", commonDiseaseID) :
                new ObjectParameter("CommonDiseaseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetCommonDiseaseDetail_Result>("UP_GetCommonDiseaseDetail", yearParameter, commonDiseaseIDParameter);
        }
    
        public virtual ObjectResult<UP_GetCommonDiseaseCountAnalysis_Result> UP_GetCommonDiseaseCountAnalysis(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetCommonDiseaseCountAnalysis_Result>("UP_GetCommonDiseaseCountAnalysis", yearParameter);
        }
    
        public virtual ObjectResult<UP_GetCommonDiseaseCountDetail_Result> UP_GetCommonDiseaseCountDetail(Nullable<int> year, Nullable<int> commonDiseaseID)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var commonDiseaseIDParameter = commonDiseaseID.HasValue ?
                new ObjectParameter("CommonDiseaseID", commonDiseaseID) :
                new ObjectParameter("CommonDiseaseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UP_GetCommonDiseaseCountDetail_Result>("UP_GetCommonDiseaseCountDetail", yearParameter, commonDiseaseIDParameter);
        }
    }
}
