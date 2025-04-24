// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Core.Configs.Builders.Extensions;
using FunQL.Core.Configs.Builders.Interfaces;
using FunQL.Core.Counting.Configs.Builders.Extensions;
using FunQL.Core.Fields.Configs.FunctionSupport.Builders.Extensions;
using FunQL.Core.Filtering.Configs.Builders.Extensions;
using FunQL.Core.Filtering.Configs.FunctionSupport.Builders.Extensions;
using FunQL.Core.Limiting.Configs.Builders.Extensions;
using FunQL.Core.Schemas;
using FunQL.Core.Skipping.Configs.Builders.Extensions;
using FunQL.Core.Sorting.Configs.Builders.Extensions;
using FunQL.Core.Sorting.Configs.FunctionSupport.Builders.Extensions;
using FunQL.Playground.Application.Features.Minifigures.Models;
using FunQL.Playground.Application.Features.Minifigures.Requests.List;

namespace FunQL.Playground.Application.Features.Minifigures.Configs;

/// <summary>Configurator to configure the <c>Minifigure</c> requests.</summary>
public class MinifigureSchemaConfigurator : ISchemaConfigurator
{
    /// <inheritdoc/>
    public void Configure(ISchemaConfigBuilder schema)
    {
        schema.Request(ListMinifiguresRequest.RequestName)
            .SupportsFilter()
            .SupportsSort()
            .SupportsLimit()
            .SupportsSkip()
            .SupportsCount()
            .ReturnsListOfObjects<Minifigure>(Configure);
    }

    /// <summary>Configures the fields of <see cref="Minifigure"/>.</summary>
    private static void Configure(IObjectTypeConfigBuilder<Minifigure> minifigure)
    {
        minifigure.SimpleField(it => it.Id)
            .HasName(Minifigure.IdPropertyName)
            .SupportsFilter(it => it.SupportsEqualityFilterFunctions())
            .SupportsSort();

        minifigure.SimpleField(it => it.Name)
            .HasName(Minifigure.NamePropertyName)
            .SupportsFilter(it => it.SupportsStringFilterFunctions())
            .SupportsSort(it => it.SupportsStringFieldFunctions());
    }
}