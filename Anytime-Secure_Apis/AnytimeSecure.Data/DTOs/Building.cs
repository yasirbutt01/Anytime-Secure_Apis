using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Building
    {
        public Building()
        {
            AdminUserLocationRecords = new HashSet<AdminUserLocationRecord>();
            Floors = new HashSet<Floor>();
            IntercomeHistories = new HashSet<IntercomeHistory>();
            Meetings = new HashSet<Meeting>();
            Rooms = new HashSet<Room>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string ZipCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Geometry GeometryPoint { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<AdminUserLocationRecord> AdminUserLocationRecords { get; set; }
        public virtual ICollection<Floor> Floors { get; set; }
        public virtual ICollection<IntercomeHistory> IntercomeHistories { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
