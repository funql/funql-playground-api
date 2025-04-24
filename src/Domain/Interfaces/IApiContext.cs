// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunQL.Playground.Domain.Interfaces;

/// <summary>Interface to access API entities.</summary>
public interface IApiContext : IDbContext
{
    /// <summary>Set for <see cref="DesignerEntity"/>.</summary>
    public DbSet<DesignerEntity> Designers { get; }
    /// <summary>Set for <see cref="MinifigureEntity"/>.</summary>
    public DbSet<MinifigureEntity> Minifigures { get; }
    /// <summary>Set for <see cref="SetEntity"/>.</summary>
    public DbSet<SetEntity> Sets { get; }
}