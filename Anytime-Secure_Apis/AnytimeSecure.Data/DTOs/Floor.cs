using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Floor
    {
        public Floor()
        {
            IntercomeHistories = new HashSet<IntercomeHistory>();
            Meetings = new HashSet<Meeting>();
            Rooms = new HashSet<Room>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal HeightInMeters { get; set; }
        public Guid? IntercomId { get; set; }
        public Guid BuildingId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Building Building { get; set; }
        public virtual Intercom Intercom { get; set; }
        public virtual ICollection<IntercomeHistory> IntercomeHistories { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
