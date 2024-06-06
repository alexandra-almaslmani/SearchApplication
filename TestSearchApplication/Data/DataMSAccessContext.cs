using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestSearchApplication.Models;

namespace TestSearchApplication.Data;

public partial class DataMSAccessContext : DbContext
{
    public DataMSAccessContext()
    {
    }

    public DataMSAccessContext(DbContextOptions<DataMSAccessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<B010105> B010105s { get; set; }

    public virtual DbSet<Tab> Tabs { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<B010105>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("b010105");

            entity.HasIndex(e => e.Mno, "MNO");

            entity.HasIndex(e => e.Tno, "Tno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mno).HasColumnName("MNO");
            entity.Property(e => e.Nass).HasColumnName("nass");
            entity.Property(e => e.Nassx).HasColumnName("NASSX");
            entity.Property(e => e.Page).HasColumnName("page");
            entity.Property(e => e.Part).HasColumnName("part");
            entity.Property(e => e.TabNo).HasMaxLength(10);

            entity.HasOne(d => d.MnoNavigation).WithMany()
                .HasForeignKey(d => d.Mno)
                .HasConstraintName("TABb010105");
        });

        modelBuilder.Entity<Tab>(entity =>
        {
            entity.HasKey(e => e.Mno).HasName("PrimaryKey");

            entity.ToTable("TAB");

            entity.HasIndex(e => e.Id, "ID").IsUnique();

            entity.HasIndex(e => e.Mno, "MNO").IsUnique();

            entity.HasIndex(e => e.Musnad, "MUSNAD");

            entity.Property(e => e.Mno)
                .ValueGeneratedNever()
                .HasColumnName("MNO");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.MhNass).HasColumnName("MH_Nass");
            entity.Property(e => e.Mtn)
                .HasDefaultValueSql("No")
                .HasColumnType("bit")
                .HasColumnName("MTN");
            entity.Property(e => e.Musnad).HasColumnName("MUSNAD");
            entity.Property(e => e.Nassx).HasColumnName("NASSX");
            entity.Property(e => e.Tmam)
                .HasDefaultValueSql("No")
                .HasColumnType("bit");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
