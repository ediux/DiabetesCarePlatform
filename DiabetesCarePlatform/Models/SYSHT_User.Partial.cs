namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SYSHT_UserMetaData))]
    public partial class SYSHT_User
    {
    }
    
    public partial class SYSHT_UserMetaData
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ParentUnitID { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string Account { get; set; }
        [Required]
        public byte[] Password { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string JobTitle { get; set; }
        public Nullable<int> AppUserID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string IdentityNumber { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> SexID { get; set; }
        public Nullable<int> RaceTypeID { get; set; }
        public Nullable<int> LanguageTypeID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Address { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string HomeTelphone { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string OfficeTelphone { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string CellPhone { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string eMail { get; set; }
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        public string MobileToken { get; set; }
        [Required]
        public bool Enable { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public System.DateTime VerifyDate { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public Nullable<System.DateTime> RemoveDate { get; set; }
    }
}
