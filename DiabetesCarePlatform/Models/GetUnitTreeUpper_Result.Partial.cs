namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(GetUnitTreeUpper_ResultMetaData))]
    public partial class GetUnitTreeUpper_Result
    {
    }
    
    public partial class GetUnitTreeUpper_ResultMetaData
    {
        public Nullable<int> UnitID { get; set; }
    }
}
