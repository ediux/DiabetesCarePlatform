namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(GetUnitTreeLower_ResultMetaData))]
    public partial class GetUnitTreeLower_Result
    {
    }
    
    public partial class GetUnitTreeLower_ResultMetaData
    {
        public Nullable<int> UnitID { get; set; }
    }
}
