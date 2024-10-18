﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using HogWildSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogWildSystem.DAL;

internal partial class HogWildContext : DbContext
{
    public HogWildContext(DbContextOptions<HogWildContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<WorkingVersion> WorkingVersions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasOne(d => d.Country).WithMany(p => p.CustomerCountries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_Country_FK");

            entity.HasOne(d => d.ProvState).WithMany(p => p.CustomerProvStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_ProvState_FK");

            entity.HasOne(d => d.Status).WithMany(p => p.CustomerStatuses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_Status_FK");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Country).WithMany(p => p.EmployeeCountries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_Country_FK");

            entity.HasOne(d => d.ProvState).WithMany(p => p.EmployeeProvStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_ProvState_FK");

            entity.HasOne(d => d.Role).WithMany(p => p.EmployeeRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_Lookup_FK");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Invoice_Customer_FK");

            entity.HasOne(d => d.Employee).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Invoice_Employee_FK");
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("InvoiceLine_Invoice_FK");

            entity.HasOne(d => d.Part).WithMany(p => p.InvoiceLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("InvoiceLine_Part_FK");
        });

        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Lookups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lookup_Category_FK");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.Property(e => e.Taxable).HasDefaultValue(true);

            entity.HasOne(d => d.PartCategory).WithMany(p => p.Parts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Part_Lookup_FK");
        });

        modelBuilder.Entity<WorkingVersion>(entity =>
        {
            entity.HasKey(e => e.VersionId).HasName("PK__WorkingV__16C6400FE0DF8E9D");

            entity.Property(e => e.Comments).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}