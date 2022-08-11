using System;
using System.Collections.Generic;

#nullable disable

namespace AnytimeSecure.Data.DTOs
{
    public partial class AdminUserProfile
    {
        public Guid Id { get; set; }
        public Guid AdminUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public string EmployeeCode { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? JobTitleId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string ZipCode { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string Color { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public bool? IsNotificationOn { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string Company { get; set; }

        public virtual AdminUser AdminUser { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual State State { get; set; }
    }
}
