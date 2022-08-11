using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class LaboratoryTest
    {
        public Guid Id { get; set; }
        public Guid LaboratoryId { get; set; }
        public Guid TestId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Laboratory Laboratory { get; set; }
        public virtual Test Test { get; set; }
    }
}
