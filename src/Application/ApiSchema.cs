// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json;
using FunQL.Core.Configs.Builders.Interfaces;
using FunQL.Core.Schemas;
using FunQL.Core.Schemas.Configs.Execute.Builders.Extensions;
using FunQL.Core.Schemas.Configs.Json.Builders.Extensions;
using FunQL.Core.Schemas.Configs.Parse.Builders.Extensions;
using FunQL.Core.Schemas.Configs.Validate.Builders.Extensions;
using FunQL.Core.Schemas.Extensions;
using FunQL.Linq.Schemas.Configs.Linq.Builders.Extensions;
using FunQL.Playground.Application.Features.Designers.Configs;
using FunQL.Playground.Application.Features.Minifigures.Configs;
using FunQL.Playground.Application.Features.Sets.Configs;
using FunQL.Playground.Application.FunQL.EFCore;
using FunQL.Playground.Application.FunQL.NodaTime;

namespace FunQL.Playground.Application;

/// <summary>FunQL schema defining the FunQL configuration for the Playground API.</summary>
/// <param name="jsonSerializerOptions">The <see cref="JsonSerializerOptions"/> to use for serializing JSON.</param>
public class ApiSchema(JsonSerializerOptions jsonSerializerOptions) : Schema
{
    /// <summary>Options to use for serializing JSON.</summary>
    private readonly JsonSerializerOptions _jsonSerializerOptions = jsonSerializerOptions;
    
    /// <inheritdoc/>
    protected override void OnInitializeSchema(ISchemaConfigBuilder schema)
    {
        // ===== Features =====
        schema.AddParseFeature();
        schema.AddValidateFeature();
        schema.AddExecuteFeature(it =>
        {
            it.WithEntityFrameworkCoreExecuteLinqExecutionHandler();
        });
        schema.AddLinqFeature(it =>
        {
            it.WithInstantFunctionLinqTranslator();
        });

        schema.JsonConfig()
            .WithJsonSerializerOptions(_jsonSerializerOptions);

        // ===== Requests =====
        schema.ApplyConfigurator(new DesignerSchemaConfigurator());
        schema.ApplyConfigurator(new MinifigureSchemaConfigurator());
        schema.ApplyConfigurator(new SetSchemaConfigurator());
    }
}