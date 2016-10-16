namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Web_GetSYSMealTypeTimingType_ResultMetaData))]
    public partial class Web_GetSYSMealTypeTimingType_Result
    {
    }
    
    public partial class Web_GetSYSMealTypeTimingType_ResultMetaData
    {
        public Nullable<int> TimingTypeID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string TimingTypeName { get; set; }
        public Nullable<int> MealTypeID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string MealTypeName { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}
