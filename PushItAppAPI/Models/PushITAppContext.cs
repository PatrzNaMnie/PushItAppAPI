using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class PushITAppContext : DbContext
    {
        public PushITAppContext()
        {
        }

        public PushITAppContext(DbContextOptions<PushITAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Historical> Historicals { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<PushUp> PushUps { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.0.157;Initial Catalog=PushITApp;Persist Security Info=True;User ID=sa;Password=Lkjiop0(;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Historical>(entity =>
            {
                entity.ToTable("Historical");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Historicals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PushUpsHistory_Users");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Arms).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Bmi)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("BMI");

                entity.Property(e => e.Bmr)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("BMR");

                entity.Property(e => e.Chest).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Waist).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Measurements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Measurements_Users");
            });

            modelBuilder.Entity<PushUp>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PushUps)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PushUps_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.HashCode)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
