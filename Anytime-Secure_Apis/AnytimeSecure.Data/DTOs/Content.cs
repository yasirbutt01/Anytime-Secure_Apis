using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class Content
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int ContentTypeId { get; set; }
        public string Version { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ContentType ContentType { get; set; }
    }
}
