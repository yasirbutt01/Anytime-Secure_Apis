using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Department
    {
        public Department()
        {
            AdminUserProfiles = new HashSet<AdminUserProfile>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual ICollection<AdminUserProfile> AdminUserProfiles { get; set; }
    }
}
