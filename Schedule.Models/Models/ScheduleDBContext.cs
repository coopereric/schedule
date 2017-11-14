using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Schedule.Models.Models
{
    public partial class ScheduleDBContext : DbContext
    {
        public ScheduleDBContext(DbContextOptions<ScheduleDBContext> options) : base(options){ }


        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Date> Date { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<MigrationLog> MigrationLog { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(local);Database=ScheduleDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.HasKey(e => e.Pkdate);

                entity.Property(e => e.Pkdate)
                    .HasColumnName("PKDate")
                    .HasColumnType("date");

                entity.Property(e => e.CalendarDayInMonth).HasColumnName("calendar_day_in_month");

                entity.Property(e => e.CalendarDayInWeek).HasColumnName("calendar_day_in_week");

                entity.Property(e => e.CalendarDayInYear).HasColumnName("calendar_day_in_year");

                entity.Property(e => e.CalendarMonth).HasColumnName("calendar_month");

                entity.Property(e => e.CalendarMonthNameLong)
                    .HasColumnName("calendar_month_name_long")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CalendarMonthNameShort)
                    .HasColumnName("calendar_month_name_short")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CalendarQuarter).HasColumnName("calendar_quarter");

                entity.Property(e => e.CalendarQuarterDesc)
                    .HasColumnName("calendar_quarter_desc")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CalendarWeekInMonth).HasColumnName("calendar_week_in_month");

                entity.Property(e => e.CalendarWeekInYear).HasColumnName("calendar_week_in_year");

                entity.Property(e => e.CalendarYear).HasColumnName("calendar_year");

                entity.Property(e => e.ContinuousDay).HasColumnName("continuous_day");

                entity.Property(e => e.ContinuousMonth).HasColumnName("continuous_month");

                entity.Property(e => e.ContinuousQuarter).HasColumnName("continuous_quarter");

                entity.Property(e => e.ContinuousWeek).HasColumnName("continuous_week");

                entity.Property(e => e.ContinuousYear).HasColumnName("continuous_year");

                entity.Property(e => e.DayNameLong)
                    .HasColumnName("day_name_long")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DayNameShort)
                    .HasColumnName("day_name_short")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsEvent).HasColumnName("is_event");

                entity.Property(e => e.IsHoliday).HasColumnName("is_holiday");

                entity.Property(e => e.IsWeekend).HasColumnName("is_weekend");

                entity.Property(e => e.IsWorkday).HasColumnName("is_workday");

                entity.Property(e => e.MdyNameLong)
                    .HasColumnName("mdy_name_long")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MdyNameLongWithSuffix)
                    .HasColumnName("mdy_name_long_with_suffix")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentLocation).HasMaxLength(50);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<MigrationLog>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.CompleteDt, e.ScriptChecksum });

                entity.ToTable("__MigrationLog");

                entity.HasIndex(e => e.CompleteDt)
                    .HasName("IX___MigrationLog_CompleteDt");

                entity.HasIndex(e => e.SequenceNo)
                    .HasName("UX___MigrationLog_SequenceNo")
                    .IsUnique();

                entity.HasIndex(e => e.Version)
                    .HasName("IX___MigrationLog_Version");

                entity.Property(e => e.MigrationId).HasColumnName("migration_id");

                entity.Property(e => e.CompleteDt).HasColumnName("complete_dt");

                entity.Property(e => e.ScriptChecksum)
                    .HasColumnName("script_checksum")
                    .HasMaxLength(64);

                entity.Property(e => e.AppliedBy)
                    .IsRequired()
                    .HasColumnName("applied_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Deployed)
                    .HasColumnName("deployed")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PackageVersion)
                    .HasColumnName("package_version")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseVersion)
                    .HasColumnName("release_version")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ScriptFilename)
                    .IsRequired()
                    .HasColumnName("script_filename")
                    .HasMaxLength(255);

                entity.Property(e => e.SequenceNo)
                    .HasColumnName("sequence_no")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasIndex(e => e.Pkdate);

                entity.HasIndex(e => e.ScheduleId)
                    .HasName("IX_Schedule")
                    .IsUnique();

                entity.HasIndex(e => e.ShiftId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Pkdate)
                    .HasColumnName("PKDate")
                    .HasColumnType("date");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.PkdateNavigation)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.Pkdate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Date");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Shift");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_AspNetUsers");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasIndex(e => e.ShiftDate);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.LunchEnd).HasColumnType("datetime");

                entity.Property(e => e.LunchStart).HasColumnType("datetime");

                entity.Property(e => e.ShiftDate).HasColumnType("date");

                entity.Property(e => e.TimeIn).HasColumnType("datetime");

                entity.Property(e => e.TimeOut).HasColumnType("datetime");

                entity.HasOne(d => d.ShiftDateNavigation)
                    .WithMany(p => p.Shift)
                    .HasForeignKey(d => d.ShiftDate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shift_Date");
            });
        }
    }
}
