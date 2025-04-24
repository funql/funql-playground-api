// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunQL.Playground.Infrastructure.Persistence.Configurations;

/// <summary>Configuration for the <see cref="SetEntity"/> based on PostgreSQL.</summary>
public class SetConfiguration : IEntityTypeConfiguration<SetEntity>
{
    /// <summary>Name of the table.</summary>
    private const string TableName = "set";
    
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<SetEntity> entity)
    {
        entity.ToTable(TableName, "application");
        
        // id
        entity.HasKey(it => it.Id)
            .HasName($"{TableName}_pkey");
        entity.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();
        
        // name
        entity.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(255)
            .IsRequired();
    
        // set_number
        entity.Property(e => e.SetNumber)
            .HasColumnName("set_number")
            .IsRequired();
        // unique (set_number)
        entity
            .HasIndex(
                e => e.SetNumber, 
                $"{TableName}_set_number_key"
            )
            .IsUnique();
    
        // pieces
        entity.Property(e => e.Pieces)
            .HasColumnName("pieces")
            .IsRequired();
    
        // price
        entity.Property(e => e.Price)
            .HasColumnName("price")
            .HasPrecision(19, 4)
            .IsRequired();

        // designer_id
        entity.Property(e => e.DesignerId)
            .HasColumnName("designer_id")
            .HasColumnType("uuid")
            .IsRequired();
        entity.HasOne(it => it.Designer)
            .WithMany()
            .HasForeignKey(d => d.DesignerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName($"{TableName}_designer_id_fkey");
        
        // launch_time
        entity.Property(e => e.LaunchTime)
            .HasColumnName("launch_time")
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        
        // packaging_type_id
        entity.Property(e => e.PackagingTypeId)
            .HasColumnName("packaging_type_id")
            .IsRequired();
        
        // theme_id
        entity.Property(e => e.ThemeId)
            .HasColumnName("theme_id")
            .IsRequired();
    }
}