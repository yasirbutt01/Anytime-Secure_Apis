using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class IntercomeHistory
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public Guid? RoomId { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime? RemovalDate { get; set; }
        public Guid IntercomId { get; set; }
        public string Name { get; set; }
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
        public virtual Room Room { get; set; }
    }
}
