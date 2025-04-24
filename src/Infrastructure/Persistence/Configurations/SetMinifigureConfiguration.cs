// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunQL.Playground.Infrastructure.Persistence.Configurations;

/// <summary>Configuration for the <see cref="SetMinifigureEntity"/> based on PostgreSQL.</summary>
public class SetMinifigureConfiguration : IEntityTypeConfiguration<SetMinifigureEntity>
{
    /// <summary>Name of the table.</summary>
    private const string TableName = "set_minifigure";
    
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<SetMinifigureEntity> entity)
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
            .WithMany(it => it.SetMinifigures)
            .HasForeignKey(d => d.SetId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName($"{TableName}_set_id_fkey");
        
        // minifigure_id
        entity.Property(e => e.MinifigureId)
            .HasColumnName("minifigure_id")
            .HasColumnType("uuid")
            .IsRequired();
        entity.HasOne(it => it.Minifigure)
            .WithMany()
            .HasForeignKey(d => d.MinifigureId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName($"{TableName}_minifigure_id_fkey");
    
        // quantity
        entity.Property(e => e.Quantity)
            .HasColumnName("quantity")
            .IsRequired();
        
        // unique (set_id, minifigure_id)
        entity
            .HasIndex(
                e => new { e.SetId, e.MinifigureId }, 
                $"{TableName}_set_id_minifigure_id_key"
            )
            .IsUnique();
    }
}