using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class RoleRight
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid RightId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Right Right { get; set; }
        public virtual Role Role { get; set; }
    }
}
