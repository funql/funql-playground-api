// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunQL.Playground.Infrastructure.Persistence.Configurations;

/// <summary>Configuration for the <see cref="SetCategoryEntity"/> based on PostgreSQL.</summary>
public class SetCategoryConfiguration : IEntityTypeConfiguration<SetCategoryEntity>
{
    /// <summary>Name of the table.</summary>
    private const string TableName = "set_category";
    
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<SetCategoryEntity> entity)
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
            .WithMany(it => it.SetCategories)
            .HasForeignKey(d => d.SetId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName($"{TableName}_set_id_fkey");
        
        // category_id
        entity.Property(e => e.CategoryId)
            .HasColumnName("category_id")
            .IsRequired();
        
        // unique (set_id, category_id)
        entity
            .HasIndex(
                e => new { e.SetId, e.CategoryId }, 
                $"{TableName}_set_id_category_id_key"
            )
            .IsUnique();
    }
}