using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Claims_Mgmt_Backend.Models
{
    public partial class claimsdbContext : DbContext
    {
        public claimsdbContext()
        {
        }

        public claimsdbContext(DbContextOptions<claimsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("claims");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimAmount).HasColumnName("claim_amount");

                entity.Property(e => e.FinalAmount).HasColumnName("final_amount");

                entity.Property(e => e.InsuranceAmount).HasColumnName("insurance_amount");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Model)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.ProcessDate)
                    .HasColumnType("date")
                    .HasColumnName("process_date");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("reason");

                entity.Property(e => e.RejReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rej_reason");

                entity.Property(e => e.ReqDate)
                    .HasColumnType("date")
                    .HasColumnName("req_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Pending')");

                entity.Property(e => e.Vno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vno");

                entity.Property(e => e.Vtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vtype");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.Memberid)
                    .HasConstraintName("FK__claims__memberid__2A4B4B5E");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("documents");

                entity.Property(e => e.Id)                    
                    .HasColumnName("id");

                entity.Property(e => e.ClaimId).HasColumnName("claim_id");

                entity.Property(e => e.Docfile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("docfile");

                entity.Property(e => e.Doctype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("doctype");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK__documents__claim__2D27B809");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("members");

                entity.HasIndex(e => e.Email, "UQ__members__AB6E6164CC233A43")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Isadmin).HasColumnName("isadmin");

                entity.Property(e => e.Mname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pwd");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
