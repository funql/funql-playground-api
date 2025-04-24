// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.WebApi.Endpoints;

namespace FunQL.Playground.WebApi.Startup;

/// <summary>Extensions related to <see cref="WebApplication"/>.</summary>
public static class WebApplicationConfig
{
    /// <summary>Configures the <see cref="WebApplication"/>.</summary>
    /// <param name="app">Application to configure.</param>
    /// <returns>The <paramref name="app"/>.</returns>
    public static WebApplication ConfigureApp(this WebApplication app) => 
        app.ConfigurePipeline()
            .ConfigureEndpoints();
    
    /// <summary>Configures the <see cref="WebApplication"/> HTTP request pipeline.</summary>
    /// <param name="app">Application to configure.</param>
    /// <returns>The <paramref name="app"/>.</returns>
    private static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseCors(WebApplicationBuilderExtensions.CorsPolicyName);

        app.UseExceptionHandler();

        return app;
    }
    
    /// <summary>Configures the <see cref="WebApplication"/> endpoints.</summary>
    /// <param name="app">Application to configure.</param>
    /// <returns>The <paramref name="app"/>.</returns>
    private static WebApplication ConfigureEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/v1beta1");
        endpoints.MapDesignerEndpoints();
        endpoints.MapMinifigureEndpoints();
        endpoints.MapSetEndpoints();

        return app;
    }
}