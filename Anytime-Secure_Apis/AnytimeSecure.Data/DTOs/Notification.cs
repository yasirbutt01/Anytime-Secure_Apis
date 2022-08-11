using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public Guid? SentToId { get; set; }
        public Guid? SentFromId { get; set; }
        public bool IsRead { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public virtual AdminUser SentFrom { get; set; }
        public virtual AdminUser SentTo { get; set; }
    }
}
