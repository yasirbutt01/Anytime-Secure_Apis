using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Test
    {
        public Test()
        {
            LaboratoryTests = new HashSet<LaboratoryTest>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal AgentCommissionInPercent { get; set; }
        public int ValidityInMinutes { get; set; }
        public int ResultTimeInMinutes { get; set; }
        public int ConductingInMinutes { get; set; }
        public int LifeInMinutes { get; set; }
        public Guid? TestAccreditationId { get; set; }
        public string UniqueId { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual TestAccreditation TestAccreditation { get; set; }
        public virtual ICollection<LaboratoryTest> LaboratoryTests { get; set; }
    }
}
