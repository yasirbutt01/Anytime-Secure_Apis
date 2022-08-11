using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class LaboratoryAddress
    {
        public Guid Id { get; set; }
        public Guid LaboratoryId { get; set; }
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
        public virtual Laboratory Laboratory { get; set; }
        public virtual State State { get; set; }
    }
}
