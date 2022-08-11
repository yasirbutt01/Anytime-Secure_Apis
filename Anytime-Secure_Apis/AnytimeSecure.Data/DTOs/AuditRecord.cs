using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class AuditRecord
    {
        public Guid Id { get; set; }
        public Guid? AuditTrailId { get; set; }
        public long AuditRecordId { get; set; }
        public string TraceId { get; set; }
        public string Action { get; set; }
        public string EntityTable { get; set; }
        public string PrimaryKey { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string ChangesJson { get; set; }
        public string ColumnValuesJson { get; set; }
        public DateTime? EventStartOn { get; set; }
        public DateTime? EventEndOn { get; set; }
        public int? EventDuration { get; set; }
        public string UserName { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public int? TenantId { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
    }
}
