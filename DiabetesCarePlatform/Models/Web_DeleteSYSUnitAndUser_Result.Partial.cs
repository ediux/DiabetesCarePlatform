namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_DeleteSYSUnitAndUser_ResultMetaData))]
    public partial class Web_DeleteSYSUnitAndUser_Result
    {
    }
    
    public partial class Web_DeleteSYSUnitAndUser_ResultMetaData
    {
        public Nullable<int> UnitID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string UnitName { get; set; }
        public Nullable<int> ParentUnitID { get; set; }
        public Nullable<int> UnitRankTypeID { get; set; }
    }
}
