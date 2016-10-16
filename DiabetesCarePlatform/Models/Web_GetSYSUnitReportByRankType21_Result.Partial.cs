namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSUnitReportByRankType21_ResultMetaData))]
    public partial class Web_GetSYSUnitReportByRankType21_Result
    {
    }
    
    public partial class Web_GetSYSUnitReportByRankType21_ResultMetaData
    {
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string ParentUnitName { get; set; }
        public Nullable<int> UnitID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string UnitName { get; set; }
        public Nullable<int> SYSUserCount { get; set; }
        public Nullable<int> DMCount { get; set; }
        public Nullable<int> UnitRankTypeID { get; set; }
        public Nullable<int> ORDER { get; set; }
    }
}
