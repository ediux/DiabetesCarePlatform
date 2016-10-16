namespace DiabetesCarePlatform.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SysDB_CreateKey_ResultMetaData))]
    public partial class SysDB_CreateKey_Result
    {
    }
    
    public partial class SysDB_CreateKey_ResultMetaData
    {
        public byte[] Column1 { get; set; }
        public Nullable<int> Column2 { get; set; }
    }
}
