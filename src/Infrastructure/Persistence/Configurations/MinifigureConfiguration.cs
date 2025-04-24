// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunQL.Playground.Infrastructure.Persistence.Configurations;

/// <summary>Configuration for the <see cref="MinifigureEntity"/> based on PostgreSQL.</summary>
public class MinifigureConfiguration : IEntityTypeConfiguration<MinifigureEntity>
{
    /// <summary>Name of the table.</summary>
    private const string TableName = "minifigure";
    
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<MinifigureEntity> entity)
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
    }
}