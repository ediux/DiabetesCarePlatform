namespace DiabetesCarePlatform.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[APP]好友绑定")]
    public partial class C_APP_好友绑定
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppUserID { get; set; }
    }
}
