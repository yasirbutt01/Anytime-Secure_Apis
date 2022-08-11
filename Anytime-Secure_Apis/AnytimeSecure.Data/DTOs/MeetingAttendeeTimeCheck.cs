using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class MeetingAttendeeTimeCheck
    {
        public Guid Id { get; set; }
        public Guid? MeetingId { get; set; }
        public Guid? MeetingAttendeeId { get; set; }
        public DateTime? TimeCheck { get; set; }
        public bool? IsCheckIn { get; set; }
        public bool? IsEnable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual MeetingAttendee MeetingAttendee { get; set; }
    }
}
