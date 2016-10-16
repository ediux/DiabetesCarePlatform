namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSUnitReportByRankType11_ResultMetaData))]
    public partial class Web_GetSYSUnitReportByRankType11_Result
    {
    }
    
    public partial class Web_GetSYSUnitReportByRankType11_ResultMetaData
    {
        public Nullable<int> UnitID { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string UnitName { get; set; }
        public Nullable<int> SYSUserCount { get; set; }
        public Nullable<int> DMCount { get; set; }
        public Nullable<int> UnitRankTypeID { get; set; }
        public Nullable<int> ORDER { get; set; }
    }
}
