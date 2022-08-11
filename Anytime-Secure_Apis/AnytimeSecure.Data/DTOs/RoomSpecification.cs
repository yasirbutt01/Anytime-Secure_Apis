using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class RoomSpecification
    {
        public RoomSpecification()
        {
            MeetingRoomSpecifications = new HashSet<MeetingRoomSpecification>();
        }

        public Guid Id { get; set; }
        public Guid SpecificationId { get; set; }
        public Guid RoomId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Room Room { get; set; }
        public virtual Specification Specification { get; set; }
        public virtual ICollection<MeetingRoomSpecification> MeetingRoomSpecifications { get; set; }
    }
}
