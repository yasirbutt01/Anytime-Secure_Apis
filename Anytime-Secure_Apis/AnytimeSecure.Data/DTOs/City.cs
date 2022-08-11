using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class City
    {
        public City()
        {
            AdminUserProfiles = new HashSet<AdminUserProfile>();
            Buildings = new HashSet<Building>();
            LaboratoryAddresses = new HashSet<LaboratoryAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }
        public string StateCode { get; set; }
        public int? CountryId { get; set; }
        public string CountryCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Geometry GeographyPoint { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool? Flag { get; set; }
        public string WikiDataId { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<AdminUserProfile> AdminUserProfiles { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<LaboratoryAddress> LaboratoryAddresses { get; set; }
    }
}
