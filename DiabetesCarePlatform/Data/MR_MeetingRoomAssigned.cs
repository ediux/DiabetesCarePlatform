using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Data
{
    public class MR_MeetingRoomAssigned
    {
        [Key]
        [Column(Order=0)]
        public int room_Id { get; set; }
        [Key]
        [Column(Order = 0)]
        [StringLength(24)]
        public string uuid { get; set; }
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string meet_id { get; set; }

        public int TimeSectionId { get; set; }

        public DateTime WorkShiftDate { get; set; }

        public int UserId { get; set; }
    }
}