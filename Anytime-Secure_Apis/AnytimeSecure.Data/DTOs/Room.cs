using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Room
    {
        public Room()
        {
            IntercomeHistories = new HashSet<IntercomeHistory>();
            Meetings = new HashSet<Meeting>();
            RoomImages = new HashSet<RoomImage>();
            RoomSpecifications = new HashSet<RoomSpecification>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int SittingCapacity { get; set; }
        public Guid? IntercomId { get; set; }
        public Guid RoomTypeId { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Building Building { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual Intercom Intercom { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<IntercomeHistory> IntercomeHistories { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<RoomImage> RoomImages { get; set; }
        public virtual ICollection<RoomSpecification> RoomSpecifications { get; set; }
    }
}
