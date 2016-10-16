namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DiabetesCarePlatformDbContext : DbContext
    {
        public DiabetesCarePlatformDbContext()
            : base("name=MainConnection")
        {
        }

        public virtual DbSet<APP_Relationship> APP_Relationship { get; set; }
        public virtual DbSet<APP_User> APP_User { get; set; }
        public virtual DbSet<CG_CareGroup> CG_CareGroup { get; set; }
        public virtual DbSet<CG_ServiceRecord> CG_ServiceRecord { get; set; }
        public virtual DbSet<CG_WorkShift> CG_WorkShift { get; set; }
        public virtual DbSet<CG_WorkShiftBase> CG_WorkShiftBase { get; set; }
        public virtual DbSet<CMR_PatientBase> CMR_PatientBase { get; set; }
        public virtual DbSet<CMR_PatientDetails> CMR_PatientDetails { get; set; }
        public virtual DbSet<CMR_PatientKey> CMR_PatientKey { get; set; }
        public virtual DbSet<PME_ExaminationBody> PME_ExaminationBody { get; set; }
        public virtual DbSet<PME_ExaminationHead> PME_ExaminationHead { get; set; }
        public virtual DbSet<PME_ExaminationType> PME_ExaminationType { get; set; }
        public virtual DbSet<PME_TagName> PME_TagName { get; set; }
        public virtual DbSet<PMR_PathologyBody> PMR_PathologyBody { get; set; }
        public virtual DbSet<PMR_PathologyHead> PMR_PathologyHead { get; set; }
        public virtual DbSet<PMR_PathologyType> PMR_PathologyType { get; set; }
        public virtual DbSet<PMR_TagName> PMR_TagName { get; set; }
        public virtual DbSet<PMRHT_PathologyBody> PMRHT_PathologyBody { get; set; }
        public virtual DbSet<SYS_ArecaTypeID> SYS_ArecaTypeID { get; set; }
        public virtual DbSet<SYS_BloodRhType> SYS_BloodRhType { get; set; }
        public virtual DbSet<SYS_BloodType> SYS_BloodType { get; set; }
        public virtual DbSet<SYS_CaseStatus> SYS_CaseStatus { get; set; }
        public virtual DbSet<SYS_ChronicSubType> SYS_ChronicSubType { get; set; }
        public virtual DbSet<SYS_ChronicType> SYS_ChronicType { get; set; }
        public virtual DbSet<SYS_City> SYS_City { get; set; }
        public virtual DbSet<SYS_Country> SYS_Country { get; set; }
        public virtual DbSet<SYS_District> SYS_District { get; set; }
        public virtual DbSet<SYS_DrinkTypeID> SYS_DrinkTypeID { get; set; }
        public virtual DbSet<SYS_EducationLevel> SYS_EducationLevel { get; set; }
        public virtual DbSet<SYS_FamilyHistoryType> SYS_FamilyHistoryType { get; set; }
        public virtual DbSet<SYS_Function> SYS_Function { get; set; }
        public virtual DbSet<SYS_Holiday> SYS_Holiday { get; set; }
        public virtual DbSet<SYS_LanguageType> SYS_LanguageType { get; set; }
        public virtual DbSet<SYS_LivingStatus> SYS_LivingStatus { get; set; }
        public virtual DbSet<SYS_LoginUser> SYS_LoginUser { get; set; }
        public virtual DbSet<SYS_MaritalStatus> SYS_MaritalStatus { get; set; }
        public virtual DbSet<SYS_MealType> SYS_MealType { get; set; }
        public virtual DbSet<SYS_ProfessionType> SYS_ProfessionType { get; set; }
        public virtual DbSet<SYS_RaceType> SYS_RaceType { get; set; }
        public virtual DbSet<SYS_RelationshipType> SYS_RelationshipType { get; set; }
        public virtual DbSet<SYS_ReligionType> SYS_ReligionType { get; set; }
        public virtual DbSet<SYS_Role> SYS_Role { get; set; }
        public virtual DbSet<SYS_RoleFunction> SYS_RoleFunction { get; set; }
        public virtual DbSet<SYS_ServiceRecordType> SYS_ServiceRecordType { get; set; }
        public virtual DbSet<SYS_ServiceResult> SYS_ServiceResult { get; set; }
        public virtual DbSet<SYS_ServiceType> SYS_ServiceType { get; set; }
        public virtual DbSet<SYS_SexType> SYS_SexType { get; set; }
        public virtual DbSet<SYS_SmokeType> SYS_SmokeType { get; set; }
        public virtual DbSet<SYS_State> SYS_State { get; set; }
        public virtual DbSet<SYS_TimingType> SYS_TimingType { get; set; }
        public virtual DbSet<SYS_Unit> SYS_Unit { get; set; }
        public virtual DbSet<SYS_UnitDetails> SYS_UnitDetails { get; set; }
        public virtual DbSet<SYS_UnitRankType> SYS_UnitRankType { get; set; }
        public virtual DbSet<SYS_UnitRole> SYS_UnitRole { get; set; }
        public virtual DbSet<SYS_UnitTask> SYS_UnitTask { get; set; }
        public virtual DbSet<SYS_User> SYS_User { get; set; }
        public virtual DbSet<SYS_UserAssignRole> SYS_UserAssignRole { get; set; }
        public virtual DbSet<SYS_UserAssignUnit> SYS_UserAssignUnit { get; set; }
        public virtual DbSet<APPHT_Relationship> APPHT_Relationship { get; set; }
        public virtual DbSet<APPHT_User> APPHT_User { get; set; }
        public virtual DbSet<CG_Message> CG_Message { get; set; }
        public virtual DbSet<CGHT_CareGroup> CGHT_CareGroup { get; set; }
        public virtual DbSet<CGHT_Message> CGHT_Message { get; set; }
        public virtual DbSet<CGHT_ServiceRecord> CGHT_ServiceRecord { get; set; }
        public virtual DbSet<CMR_Appointment> CMR_Appointment { get; set; }
        public virtual DbSet<CMR_ContactPerson> CMR_ContactPerson { get; set; }
        public virtual DbSet<CMRHT_PatientBase> CMRHT_PatientBase { get; set; }
        public virtual DbSet<CMRHT_PatientDetails> CMRHT_PatientDetails { get; set; }
        public virtual DbSet<CMRHT_PatientKey> CMRHT_PatientKey { get; set; }
        public virtual DbSet<PMEHT_ExaminationBody> PMEHT_ExaminationBody { get; set; }
        public virtual DbSet<PMEHT_ExaminationHead> PMEHT_ExaminationHead { get; set; }
        public virtual DbSet<PMRHT_PathologyHead> PMRHT_PathologyHead { get; set; }
        public virtual DbSet<SYSHT_Unit> SYSHT_Unit { get; set; }
        public virtual DbSet<SYSHT_UnitDetails> SYSHT_UnitDetails { get; set; }
        public virtual DbSet<SYSHT_UnitRole> SYSHT_UnitRole { get; set; }
        public virtual DbSet<SYSHT_User> SYSHT_User { get; set; }
        public virtual DbSet<SYSHT_UserAssignRole> SYSHT_UserAssignRole { get; set; }
        public virtual DbSet<SYSHT_UserAssignUnit> SYSHT_UserAssignUnit { get; set; }
        public virtual DbSet<SYSHT_UserLogin> SYSHT_UserLogin { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APP_User>()
                .Property(e => e.MailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<APP_User>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Function>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LoginUser>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_UnitDetails>()
                .Property(e => e.ZipCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_UnitDetails>()
                .Property(e => e.ContactTel)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_UnitDetails>()
                .Property(e => e.ContactFax)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_UnitDetails>()
                .Property(e => e.ContactMail)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_User>()
                .Property(e => e.HomeTelphone)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_User>()
                .Property(e => e.OfficeTelphone)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_User>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_User>()
                .Property(e => e.eMail)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_User>()
                .Property(e => e.MobileToken)
                .IsUnicode(false);

            modelBuilder.Entity<APPHT_User>()
                .Property(e => e.MailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<APPHT_User>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_UnitDetails>()
                .Property(e => e.ZipCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_UnitDetails>()
                .Property(e => e.ContactTel)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_UnitDetails>()
                .Property(e => e.ContactFax)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_UnitDetails>()
                .Property(e => e.ContactMail)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_User>()
                .Property(e => e.HomeTelphone)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_User>()
                .Property(e => e.OfficeTelphone)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_User>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_User>()
                .Property(e => e.eMail)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_User>()
                .Property(e => e.MobileToken)
                .IsUnicode(false);

            modelBuilder.Entity<SYSHT_UserLogin>()
                .Property(e => e.IP)
                .IsUnicode(false);
        }
    }
}
