// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace FunQL.Playground.Application;

/// <summary>Extensions for dependency injection in this namespace.</summary>
public static class ServiceCollectionExtensions
{
    /// <summary>Adds the <see cref="Application"/> services to given <paramref name="services"/>.</summary>
    /// <param name="services">Service collection to register dependencies with.</param>
    /// <param name="jsonSerializerOptionsProvider">
    /// Provider for the <see cref="JsonSerializerOptions"/> so it can be injected by the caller of this method (e.g.
    /// WebApi passing the <c>JsonOptions.SerializerOptions</c>).
    /// </param>
    /// <returns>The <see cref="IServiceCollection"/> to continue building.</returns>
    public static IServiceCollection AddApplication(
        this IServiceCollection services, 
        Func<IServiceProvider, JsonSerializerOptions> jsonSerializerOptionsProvider
    )
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
        });
        
        services.AddSingleton<ApiSchema>(it => new ApiSchema(jsonSerializerOptionsProvider(it)));
        
        return services;
    }
}