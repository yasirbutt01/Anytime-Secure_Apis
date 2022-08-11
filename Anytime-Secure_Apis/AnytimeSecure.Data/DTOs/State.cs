using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class State
    {
        public State()
        {
            AdminUserProfiles = new HashSet<AdminUserProfile>();
            Buildings = new HashSet<Building>();
            Cities = new HashSet<City>();
            LaboratoryAddresses = new HashSet<LaboratoryAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public string CountryCode { get; set; }
        public string FipsCode { get; set; }
        public string Iso2 { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Flag { get; set; }
        public string WikiDataId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<AdminUserProfile> AdminUserProfiles { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<LaboratoryAddress> LaboratoryAddresses { get; set; }
    }
}
