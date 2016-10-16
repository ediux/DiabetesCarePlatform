namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(U_FoodRecordMetaData))]
    public partial class U_FoodRecord
    {
    }
    
    public partial class U_FoodRecordMetaData
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public int FoodTypeID { get; set; }
        [Required]
        public decimal FoodValue { get; set; }
    }
}
