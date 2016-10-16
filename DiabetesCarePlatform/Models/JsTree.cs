using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class JsTree
    {
        public string text { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public JsTreeState state { get; set; }
        public List<JsTree> children { get; set; }

    }
    public class JsTreeState
    {
        public bool selected { get; set; }
        public bool disabled { get; set; }
        public bool opened { get; set; }
    }
}