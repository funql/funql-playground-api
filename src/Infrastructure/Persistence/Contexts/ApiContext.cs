// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Data;
using FunQL.Playground.Domain.Entities;
using FunQL.Playground.Domain.Interfaces;
using FunQL.Playground.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FunQL.Playground.Infrastructure.Persistence.Contexts;

/// <summary>Implementation of the <see cref="IApiContext"/> using <see cref="DbContext"/>.</summary>
/// <remarks>
/// The <see cref="DbSet{TEntity}"/> properties are set by <see cref="DbContext"/> through reflection.
/// </remarks>
public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options), IApiContext
{
    /// <inheritdoc/>
    public DbSet<DesignerEntity> Designers { get; set; } = null!;
    /// <inheritdoc/>
    public DbSet<MinifigureEntity> Minifigures { get; set; } = null!;
    /// <inheritdoc/>
    public DbSet<SetEntity> Sets { get; set; } = null!;
    
    /// <inheritdoc/>
    public Task<TResult> ExecuteInTransactionAsync<TState, TResult>(
        TState state,
        Func<TState, CancellationToken, Task<TResult>> operation,
        Func<TState, CancellationToken, Task<bool>> verifySucceeded,
        IsolationLevel isolationLevel,
        CancellationToken cancellationToken = default
    ) => Database.CreateExecutionStrategy()
        .ExecuteInTransactionAsync(state, operation, verifySucceeded, isolationLevel, cancellationToken);

    /// <inheritdoc/>
    public void AcceptAllChanges()
    {
        ChangeTracker.AcceptAllChanges();
    }
    
    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DesignerConfiguration());
        modelBuilder.ApplyConfiguration(new MinifigureConfiguration());
        modelBuilder.ApplyConfiguration(new SetConfiguration());
        modelBuilder.ApplyConfiguration(new SetCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SetItemNumberConfiguration());
        modelBuilder.ApplyConfiguration(new SetMinifigureConfiguration());
    }
}