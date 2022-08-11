using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Role
    {
        public Role()
        {
            AdminUserRoles = new HashSet<AdminUserRole>();
            RoleRights = new HashSet<RoleRight>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual ICollection<AdminUserRole> AdminUserRoles { get; set; }
        public virtual ICollection<RoleRight> RoleRights { get; set; }
    }
}
