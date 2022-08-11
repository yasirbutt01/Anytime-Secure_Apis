using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class LaboratoryContact
    {
        public LaboratoryContact()
        {
            LaboratoryLoginHistories = new HashSet<LaboratoryLoginHistory>();
        }

        public Guid Id { get; set; }
        public Guid LaboratoryId { get; set; }
        public int LaboratoryContactTypeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Laboratory Laboratory { get; set; }
        public virtual LaboratoryContactType LaboratoryContactType { get; set; }
        public virtual ICollection<LaboratoryLoginHistory> LaboratoryLoginHistories { get; set; }
    }
}
