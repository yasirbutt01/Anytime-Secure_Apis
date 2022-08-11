using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class MeetingAttendee
    {
        public MeetingAttendee()
        {
            AdminUserLocationRecords = new HashSet<AdminUserLocationRecord>();
            MeetingAttendeeTimeChecks = new HashSet<MeetingAttendeeTimeCheck>();
        }

        public Guid Id { get; set; }
        public Guid MeetingId { get; set; }
        public Guid? AttendeeId { get; set; }
        public string QrCodeUrl { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public bool IsEnable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual AdminUser Attendee { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual ICollection<AdminUserLocationRecord> AdminUserLocationRecords { get; set; }
        public virtual ICollection<MeetingAttendeeTimeCheck> MeetingAttendeeTimeChecks { get; set; }
    }
}
