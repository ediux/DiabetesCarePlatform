using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class zoom_pagedlist
    {
        public int page_count { get; set; }
        public int total_records { get; set; }
        public int page_number { get; set; }
        public int page_size { get; set; }
    
    }
}