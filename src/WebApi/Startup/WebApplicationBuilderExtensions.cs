// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json;
using System.Text.Json.Serialization;
using FunQL.Playground.Application;
using FunQL.Playground.Infrastructure;
using FunQL.Playground.WebApi.Infrastructure;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;

namespace FunQL.Playground.WebApi.Startup;

/// <summary>Extensions related to <see cref="WebApplicationBuilder"/>.</summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>Name of the CORS policy configured for this application.</summary>
    public const string CorsPolicyName = "CorsPolicy";
    
    /// <summary>Configure the <see cref="WebApplicationBuilder"/>.</summary>
    /// <param name="builder">Builder to configure.</param>
    /// <returns>The <paramref name="builder"/>.</returns>
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder) => 
        builder.ConfigureServices()
            .ConfigureModules();
    
    /// <summary>Configure the <see cref="WebApplicationBuilder.Services"/>.</summary>
    /// <param name="builder">Builder to configure services for.</param>
    /// <returns>The <paramref name="builder"/>.</returns>
    private static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

            // Pretty print by default, extra data transfer is negligible
            options.SerializerOptions.WriteIndented = true;
            // If number expected, but string given, the JSON structure is simply invalid, so set
            // JsonNumberHandling.Strict to disallow this
            options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;

            /* Converters */
            // Application uses NodaTime, so configure JSON for it
            options.SerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
        });

        // Add CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    // FunQL returns Total-Count, which can't be used by clients if not exposed
                    .WithExposedHeaders("*");
            });
        });

        builder.Services.AddProblemDetails();
        builder.Services.AddExceptionHandler<FunQLExceptionHandler>();

        return builder;
    }
    
    /// <summary>Configures modules.</summary>
    /// <param name="builder">Builder to configure services for.</param>
    /// <returns>The <paramref name="builder"/>.</returns>
    private static WebApplicationBuilder ConfigureModules(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplication(it => it.GetRequiredService<IOptions<JsonOptions>>().Value.SerializerOptions);
        builder.Services.AddInfrastructure(
            builder.Configuration.GetSection(InfrastructureOptions.Infrastructure).Get<InfrastructureOptions>()!
        );

        return builder;
    }
}