using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Meeting
    {
        public Meeting()
        {
            AdminUserLocationRecords = new HashSet<AdminUserLocationRecord>();
            MeetingAttendees = new HashSet<MeetingAttendee>();
            MeetingAttendeesCovidReports = new HashSet<MeetingAttendeesCovidReport>();
            MeetingRoomSpecifications = new HashSet<MeetingRoomSpecification>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid UserId { get; set; }
        public string Hours { get; set; }
        public bool IsCovidTestRequired { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? FloorId { get; set; }
        public int MinSeats { get; set; }
        public int MaxSeats { get; set; }
        public string Descriptions { get; set; }
        public int? MeetingStatusId { get; set; }
        public string Gmt { get; set; }
        public string ZoneName { get; set; }
        public string ShortZoneName { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Building Building { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual MeetingStatus MeetingStatus { get; set; }
        public virtual Room Room { get; set; }
        public virtual AdminUser User { get; set; }
        public virtual ICollection<AdminUserLocationRecord> AdminUserLocationRecords { get; set; }
        public virtual ICollection<MeetingAttendee> MeetingAttendees { get; set; }
        public virtual ICollection<MeetingAttendeesCovidReport> MeetingAttendeesCovidReports { get; set; }
        public virtual ICollection<MeetingRoomSpecification> MeetingRoomSpecifications { get; set; }
    }
}
