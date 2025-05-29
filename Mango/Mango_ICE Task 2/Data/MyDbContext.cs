using System;
using System.Collections.Generic;
using Mango_ICE_Task_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango_ICE_Task_2.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fruit> Fruits { get; set; }

    public virtual DbSet<Mango> Mangos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fruit>(entity =>
        {
            entity.HasKey(e => e.FruitId).HasName("PK__Fruit__F33DDB2D90C363BF");

            entity.ToTable("Fruit");

            entity.Property(e => e.FruitId).HasColumnName("FruitID");
            entity.Property(e => e.FruitField)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mango>(entity =>
        {
            entity.HasKey(e => e.MangoId).HasName("PK__Mango__AF2B4FE49454851E");

            entity.ToTable("Mango");

            entity.Property(e => e.MangoId).HasColumnName("MangoID");
            entity.Property(e => e.MangoName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
