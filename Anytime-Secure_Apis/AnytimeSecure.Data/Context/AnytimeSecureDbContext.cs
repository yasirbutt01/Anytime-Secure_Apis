using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AnytimeSecure.Data.DTOs;
using Audit.EntityFramework;


#nullable disable

namespace AnytimeSecure.Data.Context
{
    public partial class AnytimeSecureDbContext : AuditDbContext
    {
        public AnytimeSecureDbContext()
        {
        }

        public AnytimeSecureDbContext(DbContextOptions<AnytimeSecureDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<AdminUserAccess> AdminUserAccesses { get; set; }
        public virtual DbSet<AdminUserLocationRecord> AdminUserLocationRecords { get; set; }
        public virtual DbSet<AdminUserProfile> AdminUserProfiles { get; set; }
        public virtual DbSet<AdminUserRole> AdminUserRoles { get; set; }
        public virtual DbSet<AuditField> AuditFields { get; set; }
        public virtual DbSet<AuditRecord> AuditRecords { get; set; }
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentType> ContentTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Intercom> Intercoms { get; set; }
        public virtual DbSet<IntercomDetail> IntercomDetails { get; set; }
        public virtual DbSet<IntercomeHistory> IntercomeHistories { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Laboratory> Laboratories { get; set; }
        public virtual DbSet<LaboratoryAddress> LaboratoryAddresses { get; set; }
        public virtual DbSet<LaboratoryContact> LaboratoryContacts { get; set; }
        public virtual DbSet<LaboratoryContactType> LaboratoryContactTypes { get; set; }
        public virtual DbSet<LaboratoryLoginHistory> LaboratoryLoginHistories { get; set; }
        public virtual DbSet<LaboratoryTest> LaboratoryTests { get; set; }
        public virtual DbSet<LocateUser> LocateUsers { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<MeetingAttendee> MeetingAttendees { get; set; }
        public virtual DbSet<MeetingAttendeeTimeCheck> MeetingAttendeeTimeChecks { get; set; }
        public virtual DbSet<MeetingAttendeesCovidReport> MeetingAttendeesCovidReports { get; set; }
        public virtual DbSet<MeetingRoomSpecification> MeetingRoomSpecifications { get; set; }
        public virtual DbSet<MeetingStatus> MeetingStatuses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleRight> RoleRights { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomImage> RoomImages { get; set; }
        public virtual DbSet<RoomSpecification> RoomSpecifications { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestAccreditation> TestAccreditations { get; set; }
        public virtual DbSet<TestCancelReason> TestCancelReasons { get; set; }
        public virtual DbSet<TestEthnicity> TestEthnicities { get; set; }
        public virtual DbSet<TestManufacture> TestManufactures { get; set; }
        public virtual DbSet<TestMethod> TestMethods { get; set; }
        public virtual DbSet<UserDeviceInformation> UserDeviceInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Initial Catalog=sd_anytimeSecureDev;user id=rizwa;password=Rizwan@2019$;Data Source=66.85.79.26;MultipleActiveResultSets=True", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdminPassword).HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            });

            modelBuilder.Entity<AdminUserAccess>(entity =>
            {
                entity.ToTable("AdminUserAccess");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.DeviceIdentifierId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminUserAccesses)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserAccess_AdminUsers");

                entity.HasOne(d => d.Intercom)
                    .WithMany(p => p.AdminUserAccesses)
                    .HasForeignKey(d => d.IntercomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserAccess_Intercoms");
            });

            modelBuilder.Entity<AdminUserLocationRecord>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.GeometryPoint).IsRequired();

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminUserLocationRecords)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserLocationRecords_AdminUsers");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.AdminUserLocationRecords)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserLocationRecords_Buildings");

                entity.HasOne(d => d.MeetingAttendee)
                    .WithMany(p => p.AdminUserLocationRecords)
                    .HasForeignKey(d => d.MeetingAttendeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserLocationRecords_MeetingAttendees");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.AdminUserLocationRecords)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserLocationRecords_Meetings");
            });

            modelBuilder.Entity<AdminUserProfile>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.CountryCode).HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.ImageThumbnailUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.NationalId).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminUserProfiles)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserProfiles_AdminUsers");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AdminUserProfiles)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_AdminUserProfiles_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.AdminUserProfiles)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_AdminUserProfiles_Countries");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AdminUserProfiles)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_AdminUserProfiles_Departments");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.AdminUserProfiles)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserProfiles_Genders");

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.AdminUserProfiles)
                    .HasForeignKey(d => d.JobTitleId)
                    .HasConstraintName("FK_AdminUserProfiles_JobTitles");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.AdminUserProfiles)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_AdminUserProfiles_States");
            });

            modelBuilder.Entity<AdminUserRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserRoles_AdminUsers");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AdminUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserRoles_Roles");
            });

            modelBuilder.Entity<AuditField>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AuditFieldId).ValueGeneratedOnAdd();

                entity.Property(e => e.ColumnName).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.TraceId).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<AuditRecord>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.AuditRecordId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.EntityTable).HasMaxLength(50);

                entity.Property(e => e.PrimaryKey).HasMaxLength(20);

                entity.Property(e => e.PrimaryKeyValue).HasMaxLength(50);

                entity.Property(e => e.TraceId).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.AuditRecords)
                    .HasForeignKey(d => d.AuditTrailId)
                    .HasConstraintName("FK_AuditRecords_AuditTrail");
            });

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.ToTable("AuditTrail");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActionName).HasMaxLength(100);

                entity.Property(e => e.AuditTrailId).ValueGeneratedOnAdd();

                entity.Property(e => e.CallingMethod).HasMaxLength(500);

                entity.Property(e => e.ControllerName).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.EventType).HasMaxLength(100);

                entity.Property(e => e.HttpMethod).HasMaxLength(10);

                entity.Property(e => e.IpAddress).HasMaxLength(50);

                entity.Property(e => e.RequestUrl).HasMaxLength(1000);

                entity.Property(e => e.ResponseStatus).HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(1000);

                entity.Property(e => e.TraceId).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Buildings_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Buildings_Countries");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Buildings_States");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasDefaultValueSql("('2014-01-01 01:01:01')");

                entity.Property(e => e.Flag).HasDefaultValueSql("((0))");

                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.WikiDataId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Cities_Countries");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Cities_States");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contents_ContentType");
            });

            modelBuilder.Entity<ContentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Capital)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.Currency)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Emoji)
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.EmojiU)
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Iso2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ISO2")
                    .IsFixedLength(true);

                entity.Property(e => e.Iso3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ISO3")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Native)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.WikiDataId)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.HeightInMeters).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Floors)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Floors_Buildings");

                entity.HasOne(d => d.Intercom)
                    .WithMany(p => p.Floors)
                    .HasForeignKey(d => d.IntercomId)
                    .HasConstraintName("FK_Floors_Intercoms");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Intercom>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<IntercomDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApiVersion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.DeviceModel)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DeviceType)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Fimware)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Framework)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Frontend)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("IP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(350);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(350);

                entity.HasOne(d => d.Intercom)
                    .WithMany(p => p.IntercomDetails)
                    .HasForeignKey(d => d.IntercomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntercomDetails_Intercoms");
            });

            modelBuilder.Entity<IntercomeHistory>(entity =>
            {
                entity.ToTable("IntercomeHistory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AssignDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RemovalDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.IntercomeHistories)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntercomeHistory_Buildings");

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.IntercomeHistories)
                    .HasForeignKey(d => d.FloorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntercomeHistory_Floors");

                entity.HasOne(d => d.Intercom)
                    .WithMany(p => p.IntercomeHistories)
                    .HasForeignKey(d => d.IntercomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntercomeHistory_Intercoms");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.IntercomeHistories)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_IntercomeHistory_Rooms");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Laboratory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BlockedBy).HasMaxLength(450);

                entity.Property(e => e.BlockedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.LogoThumbnailUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LogoUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(50);

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("VAT");
            });

            modelBuilder.Entity<LaboratoryAddress>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.LaboratoryAddresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryAddresses_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.LaboratoryAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryAddresses_Countries");

                entity.HasOne(d => d.Laboratory)
                    .WithMany(p => p.LaboratoryAddresses)
                    .HasForeignKey(d => d.LaboratoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryAddresses_Laboratories");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.LaboratoryAddresses)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryAddresses_States");
            });

            modelBuilder.Entity<LaboratoryContact>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.LaboratoryContactType)
                    .WithMany(p => p.LaboratoryContacts)
                    .HasForeignKey(d => d.LaboratoryContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryContacts_LaboratoryContactTypes");

                entity.HasOne(d => d.Laboratory)
                    .WithMany(p => p.LaboratoryContacts)
                    .HasForeignKey(d => d.LaboratoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryContacts_Laboratories");
            });

            modelBuilder.Entity<LaboratoryContactType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<LaboratoryLoginHistory>(entity =>
            {
                entity.ToTable("LaboratoryLoginHistory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.LoginDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.LaboratoryContact)
                    .WithMany(p => p.LaboratoryLoginHistories)
                    .HasForeignKey(d => d.LaboratoryContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryLoginHistory_LaboratoryContacts");

                entity.HasOne(d => d.Laboratory)
                    .WithMany(p => p.LaboratoryLoginHistories)
                    .HasForeignKey(d => d.LaboratoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryLoginHistory_Laboratories");
            });

            modelBuilder.Entity<LaboratoryTest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Laboratory)
                    .WithMany(p => p.LaboratoryTests)
                    .HasForeignKey(d => d.LaboratoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryTests_Laboratories");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.LaboratoryTests)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LaboratoryTests_Tests");
            });

            modelBuilder.Entity<LocateUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.From)
                    .WithMany(p => p.LocateUserFroms)
                    .HasForeignKey(d => d.FromId)
                    .HasConstraintName("FK_LocateUsers_AdminUsers");

                entity.HasOne(d => d.SentToNavigation)
                    .WithMany(p => p.LocateUserSentToNavigations)
                    .HasForeignKey(d => d.SentTo)
                    .HasConstraintName("FK_LocateUsers_AdminUsers1");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Gmt)
                    .HasMaxLength(50)
                    .HasColumnName("GMT");

                entity.Property(e => e.Hours)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ShortZoneName).HasMaxLength(20);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ZoneName).HasMaxLength(200);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_Meetings_Buildings");

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.FloorId)
                    .HasConstraintName("FK_Meetings_Floors");

                entity.HasOne(d => d.MeetingStatus)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.MeetingStatusId)
                    .HasConstraintName("FK_Meetings_MeetingStatus");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Meetings_Rooms");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meetings_AdminUsers");
            });

            modelBuilder.Entity<MeetingAttendee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.QrCodeUrl).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Attendee)
                    .WithMany(p => p.MeetingAttendees)
                    .HasForeignKey(d => d.AttendeeId)
                    .HasConstraintName("FK_MeetingAttendees_AdminUsers");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.MeetingAttendees)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingAttendees_Meetings");
            });

            modelBuilder.Entity<MeetingAttendeeTimeCheck>(entity =>
            {
                entity.ToTable("meetingAttendeeTimeCheck");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.TimeCheck).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.MeetingAttendee)
                    .WithMany(p => p.MeetingAttendeeTimeChecks)
                    .HasForeignKey(d => d.MeetingAttendeeId)
                    .HasConstraintName("FK_meetingAttendeeTimeCheck_MeetingAttendees");
            });

            modelBuilder.Entity<MeetingAttendeesCovidReport>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.MeetingAttendeesCovidReports)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingAttendeesCovidReports_AdminUsers");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.MeetingAttendeesCovidReports)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingAttendeesCovidReports_Meetings");
            });

            modelBuilder.Entity<MeetingRoomSpecification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.MeetingRoomSpecifications)
                    .HasForeignKey(d => d.MeetingId)
                    .HasConstraintName("FK_MeetingRoomSpecifications_Meetings");

                entity.HasOne(d => d.RoomSpecifications)
                    .WithMany(p => p.MeetingRoomSpecifications)
                    .HasForeignKey(d => d.RoomSpecificationsId)
                    .HasConstraintName("FK_MeetingRoomSpecifications_RoomSpecifications");

                entity.HasOne(d => d.Specifications)
                    .WithMany(p => p.MeetingRoomSpecifications)
                    .HasForeignKey(d => d.SpecificationsId)
                    .HasConstraintName("FK_MeetingRoomSpecifications_Specifications");
            });

            modelBuilder.Entity<MeetingStatus>(entity =>
            {
                entity.ToTable("MeetingStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.SentFrom)
                    .WithMany(p => p.NotificationSentFroms)
                    .HasForeignKey(d => d.SentFromId)
                    .HasConstraintName("FK_Notifications_Users");

                entity.HasOne(d => d.SentTo)
                    .WithMany(p => p.NotificationSentTos)
                    .HasForeignKey(d => d.SentToId)
                    .HasConstraintName("FK_Notifications_Users1");
            });

            modelBuilder.Entity<Right>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.RightNavigation)
                    .WithMany(p => p.InverseRightNavigation)
                    .HasForeignKey(d => d.RightId)
                    .HasConstraintName("FK_Rights_Rights");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            });

            modelBuilder.Entity<RoleRight>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOnDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.Right)
                    .WithMany(p => p.RoleRights)
                    .HasForeignKey(d => d.RightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleRights_Rights");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleRights)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleRights_Roles");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_Rooms_Buildings");

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FloorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Floors");

                entity.HasOne(d => d.Intercom)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.IntercomId)
                    .HasConstraintName("FK_Rooms_Intercoms");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_RoomTypes");
            });

            modelBuilder.Entity<RoomImage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.FileThumbnailUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FileUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomImages)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomImages_Rooms");
            });

            modelBuilder.Entity<RoomSpecification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomSpecifications)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomSpecifications_Rooms");

                entity.HasOne(d => d.Specification)
                    .WithMany(p => p.RoomSpecifications)
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomSpecifications_Specifications");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SpecificationNavigation)
                    .WithMany(p => p.InverseSpecificationNavigation)
                    .HasForeignKey(d => d.SpecificationId)
                    .HasConstraintName("FK_Specifications_Specifications");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_at");

                entity.Property(e => e.FipsCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Flag).HasDefaultValueSql("((0))");

                entity.Property(e => e.Iso2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ISO2");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");

                entity.Property(e => e.WikiDataId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_States_Countries");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AgentCommissionInPercent).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.TestAccreditation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.TestAccreditationId)
                    .HasConstraintName("FK_Tests_TestAccreditations");
            });

            modelBuilder.Entity<TestAccreditation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestCancelReason>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestEthnicity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestManufacture>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestMethod>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserDeviceInformation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DeletedBy).HasMaxLength(450);

                entity.Property(e => e.DeviceModel).HasMaxLength(200);

                entity.Property(e => e.DeviceToken).HasMaxLength(1000);

                entity.Property(e => e.Gmtdiffrence).HasColumnName("GMTDiffrence");

                entity.Property(e => e.Ip)
                    .HasMaxLength(20)
                    .HasColumnName("IP");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Os)
                    .HasMaxLength(20)
                    .HasColumnName("OS");

                entity.Property(e => e.UniqueKey).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.Version).HasMaxLength(300);

                entity.Property(e => e.VersionName).HasMaxLength(500);

                entity.Property(e => e.VoipdeviceToken)
                    .HasMaxLength(1000)
                    .HasColumnName("VOIPDeviceToken");

                entity.HasOne(d => d.AdminUser)
                    .WithMany(p => p.UserDeviceInformations)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDeviceInformations_Users");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.UserDeviceInformations)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDeviceInformations_DeviceTypes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
