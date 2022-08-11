using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class MeetingRoomSpecification
    {
        public Guid Id { get; set; }
        public Guid? MeetingId { get; set; }
        public Guid? RoomSpecificationsId { get; set; }
        public Guid? SpecificationsId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual RoomSpecification RoomSpecifications { get; set; }
        public virtual Specification Specifications { get; set; }
    }
}
