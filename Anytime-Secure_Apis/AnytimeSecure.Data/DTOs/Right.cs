using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Right
    {
        public Right()
        {
            InverseRightNavigation = new HashSet<Right>();
            RoleRights = new HashSet<RoleRight>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public Guid? RightId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Right RightNavigation { get; set; }
        public virtual ICollection<Right> InverseRightNavigation { get; set; }
        public virtual ICollection<RoleRight> RoleRights { get; set; }
    }
}
