using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class AdminUserLocationRecord
    {
        public Guid Id { get; set; }
        public Guid AdminUserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Geometry GeometryPoint { get; set; }
        public Guid BuildingId { get; set; }
        public Guid MeetingId { get; set; }
        public Guid MeetingAttendeeId { get; set; }
        public bool IsInPremises { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual AdminUser AdminUser { get; set; }
        public virtual Building Building { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual MeetingAttendee MeetingAttendee { get; set; }
    }
}
