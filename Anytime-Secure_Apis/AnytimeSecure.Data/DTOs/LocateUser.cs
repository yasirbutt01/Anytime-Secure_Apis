using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class LocateUser
    {
        public Guid Id { get; set; }
        public Guid? FromId { get; set; }
        public Guid? SentTo { get; set; }
        public int? Status { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool? IsEnable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual AdminUser From { get; set; }
        public virtual AdminUser SentToNavigation { get; set; }
    }
}
