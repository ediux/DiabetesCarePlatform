using DiabetesCarePlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models.ZoomNetMeeting
{
    public class ZoomMeetingPageListViewModel : IZoomMeetingPageListViewModel
    {
        public ZoomMeetingPageListViewModel()
        {
            pagecount = 0;
            totalrecords = 0;
            pagenumber = 1;
            pagesize = 10;
            rows = new List<IZoom_Meeting_ListItem_ViewModel>();
        }
        private int pagecount;
        public int PageCount
        {
            get
            {
                return pagecount;
            }
            set
            {
                pagecount = value;
            }
        }
        private int totalrecords;
        public int TotalRecords
        {
            get
            {
                return totalrecords;
            }
            set
            {
                totalrecords = value;
            }
        }

        private int pagenumber;
        public int PageNumber
        {
            get
            {
                return pagenumber;
            }
            set
            {
                pagenumber = value;
            }
        }

        private int pagesize;
        public int PageSize
        {
            get
            {
                return pagesize;
            }
            set
            {
                pagesize = value;
            }
        }

        private List<IZoom_Meeting_ListItem_ViewModel> rows;

        public List<IZoom_Meeting_ListItem_ViewModel> Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }
    }
}