using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Infrastructure
{
    public partial class API_TESTContext : DbContext
    {
        public API_TESTContext()
        {
        }

        public API_TESTContext(DbContextOptions<API_TESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-HHSNLMNF;Database=API_TEST; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.PkEmpId);

                entity.Property(e => e.PkEmpId).HasColumnName("PK_EMP_ID");

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Position).HasMaxLength(100);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.PkRfTk);

                entity.Property(e => e.PkRfTk).HasColumnName("PK_RF_TK");

                entity.Property(e => e.CreateByIp).HasMaxLength(50);

                entity.Property(e => e.CreateByUser).HasMaxLength(50);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.ReplacedByToken).HasMaxLength(150);

                entity.Property(e => e.Revoked).HasColumnType("datetime");

                entity.Property(e => e.RevokedByIp).HasMaxLength(50);

                entity.Property(e => e.RevokedByUser).HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(150);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.PkUid);

                entity.Property(e => e.PkUid).HasColumnName("PK_UID");

                entity.Property(e => e.FkEmpId).HasColumnName("FK_EMP_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
