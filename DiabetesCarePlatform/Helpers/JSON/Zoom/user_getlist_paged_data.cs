using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.JSON.Zoom
{
    public class user_getlist_paged_data : zoom_pagedlist
    {
        public user_getlist_paged_data()
            : base()
        {

        }
        public user_listdata_data[] users { get; set; }
    }
}