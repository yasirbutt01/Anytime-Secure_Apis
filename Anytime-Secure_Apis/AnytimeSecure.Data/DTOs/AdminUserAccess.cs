using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class AdminUserAccess
    {
        public Guid Id { get; set; }
        public Guid IntercomId { get; set; }
        public Guid AdminUserId { get; set; }
        public string DeviceIdentifierId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual AdminUser AdminUser { get; set; }
        public virtual Intercom Intercom { get; set; }
    }
}
