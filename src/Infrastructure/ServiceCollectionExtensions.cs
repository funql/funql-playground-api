// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Domain.Interfaces;
using FunQL.Playground.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FunQL.Playground.Infrastructure;

/// <summary>Extensions for dependency injection in this namespace.</summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="Infrastructure"/> services to given <paramref name="services"/> based on given
    /// <paramref name="options"/>.
    /// </summary>
    /// <param name="services">Service collection to register dependencies with.</param>
    /// <param name="options">Options for the <see cref="Infrastructure"/> services.</param>
    /// <returns>The <see cref="IServiceCollection"/> to continue building.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureOptions options)
    {
        services.AddDbContext<IApiContext, ApiContext>(dbOptions =>
        {

            dbOptions.UseNpgsql(
                options.ConnectionString,
                npgsqlOptions => npgsqlOptions
                    .UseNodaTime()
                    .EnableRetryOnFailure(3)
            );
        });
        
        return services;
    }
    
}