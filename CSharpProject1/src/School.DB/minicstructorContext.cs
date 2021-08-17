using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School.DB
{
    public partial class minicstructorContext : DbContext
    {
        public minicstructorContext()
        {
        }

        public minicstructorContext(DbContextOptions<minicstructorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassMaster> ClassMaster { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClass> UserClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=pjbuw-sv.database.windows.net;Initial Catalog=mini-cstructor;User Id=pjbadmin;Password=Dressel1!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassMaster>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClassPrice).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserClass>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.UserId });

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.UserClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClass_Class");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClass)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClass_User");
            });
        }
    }
}
