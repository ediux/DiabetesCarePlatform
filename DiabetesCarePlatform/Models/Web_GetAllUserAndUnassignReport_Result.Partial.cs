namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetAllUserAndUnassignReport_ResultMetaData))]
    public partial class Web_GetAllUserAndUnassignReport_Result
    {
    }
    
    public partial class Web_GetAllUserAndUnassignReport_ResultMetaData
    {
        public Nullable<int> ParentUnitID { get; set; }
        [Required]
        public int UnitRankTypeID { get; set; }
        [Required]
        public int UserID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string Account { get; set; }
        public Nullable<int> SexID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string JobTitle { get; set; }
    }
}
