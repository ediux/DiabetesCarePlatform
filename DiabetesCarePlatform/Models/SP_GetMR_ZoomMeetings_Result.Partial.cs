namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SP_GetMR_ZoomMeetings_ResultMetaData))]
    public partial class SP_GetMR_ZoomMeetings_Result
    {
    }
    
    public partial class SP_GetMR_ZoomMeetings_ResultMetaData
    {
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        public string Id { get; set; }
        
        [StringLength(24, ErrorMessage="欄位長度不得大於 24 個字元")]
        [Required]
        public string uuid { get; set; }
        
        [StringLength(2048, ErrorMessage="欄位長度不得大於 2048 個字元")]
        public string start_url { get; set; }
        
        [StringLength(2048, ErrorMessage="欄位長度不得大於 2048 個字元")]
        public string join_url { get; set; }
        [Required]
        public System.DateTime created_at { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string host_id { get; set; }
        
        [StringLength(300, ErrorMessage="欄位長度不得大於 300 個字元")]
        [Required]
        public string topic { get; set; }
        [Required]
        public int type { get; set; }
        public Nullable<System.DateTime> start_time { get; set; }
        public Nullable<int> duration { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string timezone { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string password { get; set; }
        public Nullable<bool> option_jbh { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string option_start_type { get; set; }
        public Nullable<bool> option_host_video { get; set; }
        public Nullable<bool> option_participants_video { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string option_audio { get; set; }
        [Required]
        public int userid { get; set; }
    }
}
