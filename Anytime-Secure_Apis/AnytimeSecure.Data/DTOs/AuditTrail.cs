using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class AuditTrail
    {
        public AuditTrail()
        {
            AuditRecords = new HashSet<AuditRecord>();
        }

        public Guid Id { get; set; }
        public long AuditTrailId { get; set; }
        public string TraceId { get; set; }
        public string EventType { get; set; }
        public string RequestUrl { get; set; }
        public string HttpMethod { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string CallingMethod { get; set; }
        public string IpAddress { get; set; }
        public string ResponseStatus { get; set; }
        public int? ResponseCode { get; set; }
        public DateTime? EventStartOn { get; set; }
        public DateTime? EventEndOn { get; set; }
        public int? EventDuration { get; set; }
        public string EnvironmentJsonData { get; set; }
        public string ActionJsonData { get; set; }
        public string ExceptionJsonData { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public int? TenantId { get; set; }

        public virtual ICollection<AuditRecord> AuditRecords { get; set; }
    }
}
