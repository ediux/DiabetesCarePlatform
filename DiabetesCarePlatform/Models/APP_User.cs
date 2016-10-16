using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class APP_User
    {
        public int AppUserID { get; set; }
        [Required]
        public string MailAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int SexID { get; set; }
        [StringLength(30)]
        public string IdentityNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int ChronicSubTypeID { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public decimal BodyHeight { get; set; }
        public decimal BodyWeight { get; set; }
        [StringLength(50)]
        public string MobileToken { get; set; }
        [StringLength(10)]
        public string MobileNumber { get; set; }
        public bool NoiceByPush { get; set; }
        public bool NoiceByMessage { get; set; }
        public bool NoiceByPhone { get; set; }
        public bool Enable { get; set; }
        public int PaymentType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime VerifyDate { get; set; }
        public int LastUserID { get; set; }
        public DateTime LastUpdate { get; set; }
    }
    public class APP_User_Extend : APP_User
    {
        public int PatientID { get; set; }
        public List<int> UnitList { get; set; }
    }
}