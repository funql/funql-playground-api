// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunQL.Playground.Infrastructure.Persistence.Configurations;

/// <summary>Configuration for the <see cref="SetItemNumberEntity"/> based on PostgreSQL.</summary>
public class SetItemNumberConfiguration : IEntityTypeConfiguration<SetItemNumberEntity>
{
    /// <summary>Name of the table.</summary>
    private const string TableName = "set_item_number";
    
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<SetItemNumberEntity> entity)
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

        // set_id
        entity.Property(e => e.SetId)
            .HasColumnName("set_id")
            .HasColumnType("uuid")
            .IsRequired();
        entity.HasOne<SetEntity>()
            .WithMany(it => it.SetItemNumbers)
            .HasForeignKey(d => d.SetId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName($"{TableName}_set_id_fkey");
        
        // region_id
        entity.Property(e => e.RegionId)
            .HasColumnName("region_id")
            .IsRequired();
    
        // item_number
        entity.Property(e => e.ItemNumber)
            .HasColumnName("item_number")
            .IsRequired();
        
        // unique (set_id, region_id)
        entity
            .HasIndex(
                e => new { e.SetId, e.RegionId }, 
                $"{TableName}_set_id_region_id_key"
            )
            .IsUnique();
    }
}