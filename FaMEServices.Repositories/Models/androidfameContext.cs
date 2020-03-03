using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FaMEServices.Repositories.Models
{
    public partial class androidfameContext : DbContext
    {
        public androidfameContext()
        {
        }

        public androidfameContext(DbContextOptions<androidfameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppaAccessLog> AppaAccessLog { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=182.18.157.40;Initial Catalog=androidfame;User ID=android;Password=android@fame;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppaAccessLog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppaAccessLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CheckInLatitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.CheckInLongitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.CheckOutLatitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.CheckOutLongitude).HasColumnType("decimal(11, 8)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmailId).HasMaxLength(160);

                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(80);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmailId).HasMaxLength(160);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(80);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.EmailId).HasMaxLength(160);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(80);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_User_Client_ClientId");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_User_Company_CompanyId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role_RoleId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
