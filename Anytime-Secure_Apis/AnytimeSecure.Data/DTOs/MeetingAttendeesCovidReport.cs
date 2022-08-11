using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class MeetingAttendeesCovidReport
    {
        public Guid Id { get; set; }
        public Guid AdminUserId { get; set; }
        public Guid MeetingId { get; set; }
        public bool IsReportAttached { get; set; }
        public bool IsEnable { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual AdminUser AdminUser { get; set; }
        public virtual Meeting Meeting { get; set; }
    }
}
