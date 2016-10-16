namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(GetUnitTreeFull_ResultMetaData))]
    public partial class GetUnitTreeFull_Result
    {
    }
    
    public partial class GetUnitTreeFull_ResultMetaData
    {
        public Nullable<int> UnitID { get; set; }
    }
}
