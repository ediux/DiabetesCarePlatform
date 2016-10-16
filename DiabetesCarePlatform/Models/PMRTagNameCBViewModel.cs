using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class PMRTagNameCBViewModel
    {
        [System.ComponentModel.DefaultValue(false)]
        public bool Checked { get; set; }
        public int PathologyID { get; set; }
        public int PathologyTypeID { get; set; }
        public string TagName { get; set; }

        public string Description { get; set; }
    }
}