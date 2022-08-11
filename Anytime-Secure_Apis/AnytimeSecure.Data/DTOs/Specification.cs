using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Specification
    {
        public Specification()
        {
            InverseSpecificationNavigation = new HashSet<Specification>();
            MeetingRoomSpecifications = new HashSet<MeetingRoomSpecification>();
            RoomSpecifications = new HashSet<RoomSpecification>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? SpecificationId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Specification SpecificationNavigation { get; set; }
        public virtual ICollection<Specification> InverseSpecificationNavigation { get; set; }
        public virtual ICollection<MeetingRoomSpecification> MeetingRoomSpecifications { get; set; }
        public virtual ICollection<RoomSpecification> RoomSpecifications { get; set; }
    }
}
