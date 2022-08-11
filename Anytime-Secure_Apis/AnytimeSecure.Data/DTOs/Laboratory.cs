using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Laboratory
    {
        public Laboratory()
        {
            LaboratoryAddresses = new HashSet<LaboratoryAddress>();
            LaboratoryContacts = new HashSet<LaboratoryContact>();
            LaboratoryLoginHistories = new HashSet<LaboratoryLoginHistory>();
            LaboratoryTests = new HashSet<LaboratoryTest>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string UniqueId { get; set; }
        public string LogoUrl { get; set; }
        public string LogoThumbnailUrl { get; set; }
        public string ShortCode { get; set; }
        public decimal Vat { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsBlocked { get; set; }
        public string BlockedBy { get; set; }
        public DateTime? BlockedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual ICollection<LaboratoryAddress> LaboratoryAddresses { get; set; }
        public virtual ICollection<LaboratoryContact> LaboratoryContacts { get; set; }
        public virtual ICollection<LaboratoryLoginHistory> LaboratoryLoginHistories { get; set; }
        public virtual ICollection<LaboratoryTest> LaboratoryTests { get; set; }
    }
}
