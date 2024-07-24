using System;
using System.Collections.Generic;
using DealerPortalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DealerPortalApp.Data;

public partial class DealerPortalContext : DbContext
{
    public DealerPortalContext()
    {
    }

    public DealerPortalContext(DbContextOptions<DealerPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DevConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("PK__Applican__39AE9148BDBF19CF");

            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.ApplicantName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD43745D7B64C");

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Loans)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loans__Applicant__4E88ABD4");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__FC8618D3A6152AC4");

            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.Make)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK__Vendors__Applica__52593CB8");

            entity.HasOne(d => d.Loan).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("FK__Vendors__LoanID__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
