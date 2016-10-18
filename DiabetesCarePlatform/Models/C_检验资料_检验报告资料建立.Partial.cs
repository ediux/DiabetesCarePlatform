namespace DiabetesCarePlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(C_检验资料_检验报告资料建立MetaData))]
    public partial class C_检验资料_检验报告资料建立
    {
    }
    
    public partial class C_检验资料_检验报告资料建立MetaData
    {
        [Required]
        public long HeadID { get; set; }
    }
}
