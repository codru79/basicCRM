using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using basicCRM.Models.DBObjects;

namespace basicCRM.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<ContactPerson> ContactPersons { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Opportunity> Opportunities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.HasKey(e => e.IdcontactPerson)
                    .HasName("PK__Customer__55BAF6418D9E826E");

                entity.Property(e => e.IdcontactPerson)
                    .ValueGeneratedNever()
                    .HasColumnName("IDContactPerson");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcustomerNavigation)
                    .WithMany(p => p.ContactPeople)
                    .HasForeignKey(d => d.Idcustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactPersons_Customers");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Idcustomer)
                    .HasName("PK__Customer__701C9C3CE5AF16EB");

                entity.Property(e => e.Idcustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCustomer");

                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.Adress).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Idemployee)
                    .HasName("PK__Employee__1348E88CEF53E14A");

                entity.Property(e => e.Idemployee)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEmployee");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idrole)
                    .HasMaxLength(450)
                    .HasColumnName("IDRole");

                entity.Property(e => e.IduserLogin)
                    .HasMaxLength(450)
                    .HasColumnName("IDUserLogin");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Idrole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roleid");

                entity.HasOne(d => d.IduserLoginNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IduserLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserLoginid");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.Idoffer)
                    .HasName("PK__Offers__F1E50DFC2C2B047A");

                entity.Property(e => e.Idoffer)
                    .ValueGeneratedNever()
                    .HasColumnName("IDOffer");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ExpireDate).HasColumnType("date");

                entity.Property(e => e.Idopportunity).HasColumnName("IDOpportunity");

                entity.Property(e => e.Idowner).HasColumnName("IDOwner");

                entity.Property(e => e.OfferType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValueMwh).HasColumnName("Value(MWh)");

                entity.HasOne(d => d.IdopportunityNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.Idopportunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offers_Opportunities");

                entity.HasOne(d => d.IdownerNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.Idowner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offers_Employees");
            });

            modelBuilder.Entity<Opportunity>(entity =>
            {
                entity.HasKey(e => e.Idopportunity)
                    .HasName("PK__tmp_ms_x__977507ECAC3A0C49");

                entity.Property(e => e.Idopportunity)
                    .ValueGeneratedNever()
                    .HasColumnName("IDOpportunity");

                entity.Property(e => e.CommodityType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");

                entity.Property(e => e.Idowner).HasColumnName("IDOwner");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("date");

                entity.Property(e => e.ValidTo).HasColumnType("date");

                entity.HasOne(d => d.IdcustomerNavigation)
                    .WithMany(p => p.Opportunities)
                    .HasForeignKey(d => d.Idcustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Opportunities_Customers");

                entity.HasOne(d => d.IdownerNavigation)
                    .WithMany(p => p.Opportunities)
                    .HasForeignKey(d => d.Idowner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Opportunities_Employees");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
