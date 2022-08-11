using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Country
    {
        public Country()
        {
            AdminUserProfiles = new HashSet<AdminUserProfile>();
            Buildings = new HashSet<Building>();
            Cities = new HashSet<City>();
            LaboratoryAddresses = new HashSet<LaboratoryAddress>();
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public string PhoneCode { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string Native { get; set; }
        public string Emoji { get; set; }
        public string EmojiU { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Flag { get; set; }
        public string WikiDataId { get; set; }

        public virtual ICollection<AdminUserProfile> AdminUserProfiles { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<LaboratoryAddress> LaboratoryAddresses { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
