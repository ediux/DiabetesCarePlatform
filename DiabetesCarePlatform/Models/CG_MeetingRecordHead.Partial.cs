namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CG_MeetingRecordHeadMetaData))]
    public partial class CG_MeetingRecordHead
    {
    }
    
    public partial class CG_MeetingRecordHeadMetaData
    {
        public Nullable<long> ID { get; set; }
        [Required]
        public int AppUserID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int ChronicTypeID { get; set; }
        [Required]
        public int UnitID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public System.TimeSpan StartTime { get; set; }
        [Required]
        public System.TimeSpan EndTime { get; set; }
        [Required]
        public int LastUserID { get; set; }
        [Required]
        public System.DateTime LastUpdate { get; set; }
    }
}
