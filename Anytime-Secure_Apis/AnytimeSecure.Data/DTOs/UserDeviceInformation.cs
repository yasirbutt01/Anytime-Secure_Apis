using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class UserDeviceInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VersionName { get; set; }
        public string Version { get; set; }
        public string VoipdeviceToken { get; set; }
        public string UniqueKey { get; set; }
        public string DeviceToken { get; set; }
        public Guid AdminUserId { get; set; }
        public int DeviceTypeId { get; set; }
        public string Os { get; set; }
        public string DeviceModel { get; set; }
        public int? Gmtdiffrence { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string Ip { get; set; }

        public virtual AdminUser AdminUser { get; set; }
        public virtual DeviceType DeviceType { get; set; }
    }
}
