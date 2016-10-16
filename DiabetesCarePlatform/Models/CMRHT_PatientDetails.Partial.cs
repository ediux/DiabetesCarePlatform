namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CMRHT_PatientDetailsMetaData))]
    public partial class CMRHT_PatientDetails
    {
    }
    
    public partial class CMRHT_PatientDetailsMetaData
    {
        [Required]
        public int PatientID { get; set; }
        public Nullable<int> NowCountryID { get; set; }
        public Nullable<int> NowStateID { get; set; }
        public Nullable<int> NowCityID { get; set; }
        public Nullable<int> NowDistrictID { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string NowAddress { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string HomeTelphone { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string OfficeTelphone { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string CellPhone { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string eMail { get; set; }
        public Nullable<int> LivingStatus { get; set; }
        public Nullable<int> ProfessionID { get; set; }
        public Nullable<int> SmokeTypeID { get; set; }
        public Nullable<int> DrinkTypeID { get; set; }
        public Nullable<int> ArecaTypeID { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
