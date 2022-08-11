using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Intercom
    {
        public Intercom()
        {
            AdminUserAccesses = new HashSet<AdminUserAccess>();
            Floors = new HashSet<Floor>();
            IntercomDetails = new HashSet<IntercomDetail>();
            IntercomeHistories = new HashSet<IntercomeHistory>();
            Rooms = new HashSet<Room>();
        }

        public Guid Id { get; set; }
        public bool IsOnline { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual ICollection<AdminUserAccess> AdminUserAccesses { get; set; }
        public virtual ICollection<Floor> Floors { get; set; }
        public virtual ICollection<IntercomDetail> IntercomDetails { get; set; }
        public virtual ICollection<IntercomeHistory> IntercomeHistories { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
