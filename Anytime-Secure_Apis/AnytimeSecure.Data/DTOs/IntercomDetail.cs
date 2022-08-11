using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class IntercomDetail
    {
        public Guid Id { get; set; }
        public Guid IntercomId { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fimware { get; set; }
        public string ApiVersion { get; set; }
        public string Framework { get; set; }
        public string Frontend { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual Intercom Intercom { get; set; }
    }
}
