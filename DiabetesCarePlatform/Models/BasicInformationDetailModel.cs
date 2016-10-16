using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DiabetesCarePlatform.Models
{
    public class BasicInformationModel
    {
        //public List<BasicInformationDetailModel> BasicInformationDetailList { get; set; }
        public BasicInformationDetailModel BIDMItem { get; set; }
        public List<ContactPersonModel> ContactPersonList { get; set; }
        public List<PMRPathologyModel> PathologyList { get; set; }
    }

    public class BasicInformationDetailModel
    {
        public int PatientID { get; set; }
        [StringLength(30)]
        public string PatientName { get; set; }
        public int SexID { get; set; }
        public string SexName { get; set; }
        [StringLength(30)]
        public string IdentityNumber { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(30)]
        public string DisabledID { get; set; }
        public int BloodTypeID { get; set; }
        public string BloodTypeName { get; set; }
        public int BloodRhTypeID { get; set; }
        public string BloodRhTypeName { get; set; }
        public int RaceTypeID { get; set; }
        public string RaceTypeName { get; set; }
        public int LanguageTypeID { get; set; }
        public string LanguageTypeName { get; set; }
        public int ReligionTypeID { get; set; }
        public string ReligionTypeName { get; set; }
        public int MaritalStatus { get; set; }
        public string MaritalStatusName { get; set; }
        public int EducationLevelID { get; set; }
        public string EducationLevelName { get; set; }
        public string CaseStatus { get; set; }
        public int ChronicSubTypeID { get; set; }
        public string ChronicSubName { get; set; }
        public int RegisterCountryID { get; set; }
        public string CountryName { get; set; }
        public int RegisterStateID { get; set; }
        public string StateName { get; set; }
        public int RegisterCityID { get; set; }
        public string CityName { get; set; }
        public int RegisterDistrictID { get; set; }
        public string DistrictName { get; set; }
        [StringLength(100)]
        public string RegisterAddress { get; set; }
        public int NowCountryID { get; set; }
        public string NowCountryName { get; set; }
        public int NowStateID { get; set; }
        public string NowStateName { get; set; }
        public int NowCityID { get; set; }
        public string NowCityName { get; set; }
        public int NowDistrictID { get; set; }
        public string NowDistrictName { get; set; }
        [StringLength(100)]
        public string NowAddress { get; set; }
        [StringLength(20)]
        public string CellPhone { get; set; }
        [StringLength(20)]
        public string HomeTelphone { get; set; }
        [StringLength(20)]
        public string OfficeTelphone { get; set; }
        [StringLength(50)]
        public string eMail { get; set; }
        public int LivingStatus { get; set; }
        public string LivingStatusName { get; set; }
        public int ProfessionID { get; set; }
        public string ProfessionTypeName { get; set; }
        public int SmokeTypeID { get; set; }
        public string SmokeTypeName { get; set; }
        public int DrinkTypeID { get; set; }
        public string DrinkTypeName { get; set; }
        public int ArecaTypeID { get; set; }
        public string ArecaTypeName { get; set; }

    }

    public class ContactPersonModel
    {
        public int PatientID { get; set; }
        public string ContactName { get; set; }
        public string Description { get; set; }
        public string SexName { get; set; }
        [StringLength(20)]
        public string HomeTelphone { get; set; }
        [StringLength(20)]
        public string OfficeTelphone { get; set; }
        [StringLength(20)]
        public string CellPhone { get; set; }
        [StringLength(50)]
        public string MailAddress { get; set; }
    }

    public class PMRPathologyModel
    {
        public int PatientID { get; set; }
        public string ChronicName { get; set; }
        public string ChronicSubName { get; set; }
        public string FamilyHistoryTypeName { get; set; }
        public int PathologyTypeID{ get; set; }
        public string PMR_PathologyType { get; set; }
        public string PMR_TagName { get; set; }
        public string ResultValue { get; set; }
    }

}