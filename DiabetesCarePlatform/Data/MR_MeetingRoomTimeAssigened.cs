using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Data
{
    public class MR_MeetingRoomTimeAssigened
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int TimeSectionId { get; set; }
        public int DayOfWeek { get; set; }
    }
}