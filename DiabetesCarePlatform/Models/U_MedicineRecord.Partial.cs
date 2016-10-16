namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(U_MedicineRecordMetaData))]
    public partial class U_MedicineRecord
    {
    }
    
    public partial class U_MedicineRecordMetaData
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public int AppUserID { get; set; }
        [Required]
        public System.DateTime RecordTime { get; set; }
        [Required]
        public int TimingTypeID { get; set; }
        [Required]
        public int MedicineID { get; set; }
        [Required]
        public decimal MedicineValue { get; set; }
    }
}
