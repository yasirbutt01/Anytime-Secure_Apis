using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class AdminUser
    {
        public AdminUser()
        {
            AdminUserAccesses = new HashSet<AdminUserAccess>();
            AdminUserLocationRecords = new HashSet<AdminUserLocationRecord>();
            AdminUserProfiles = new HashSet<AdminUserProfile>();
            AdminUserRoles = new HashSet<AdminUserRole>();
            LocateUserFroms = new HashSet<LocateUser>();
            LocateUserSentToNavigations = new HashSet<LocateUser>();
            MeetingAttendees = new HashSet<MeetingAttendee>();
            MeetingAttendeesCovidReports = new HashSet<MeetingAttendeesCovidReport>();
            Meetings = new HashSet<Meeting>();
            NotificationSentFroms = new HashSet<Notification>();
            NotificationSentTos = new HashSet<Notification>();
            UserDeviceInformations = new HashSet<UserDeviceInformation>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AdminPassword { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool? IsCompanyEmployee { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsEnabled { get; set; }
        public int? Otp { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual ICollection<AdminUserAccess> AdminUserAccesses { get; set; }
        public virtual ICollection<AdminUserLocationRecord> AdminUserLocationRecords { get; set; }
        public virtual ICollection<AdminUserProfile> AdminUserProfiles { get; set; }
        public virtual ICollection<AdminUserRole> AdminUserRoles { get; set; }
        public virtual ICollection<LocateUser> LocateUserFroms { get; set; }
        public virtual ICollection<LocateUser> LocateUserSentToNavigations { get; set; }
        public virtual ICollection<MeetingAttendee> MeetingAttendees { get; set; }
        public virtual ICollection<MeetingAttendeesCovidReport> MeetingAttendeesCovidReports { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Notification> NotificationSentFroms { get; set; }
        public virtual ICollection<Notification> NotificationSentTos { get; set; }
        public virtual ICollection<UserDeviceInformation> UserDeviceInformations { get; set; }
    }
}
