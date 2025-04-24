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
using FunQL.Playground.Application.Features.Designers.Models;
using FunQL.Playground.Application.Features.Designers.Requests.List;

namespace FunQL.Playground.Application.Features.Designers.Configs;

/// <summary>Configurator to configure the <c>Designer</c> requests.</summary>
public class DesignerSchemaConfigurator : ISchemaConfigurator
{
    /// <inheritdoc/>
    public void Configure(ISchemaConfigBuilder schema)
    {
        schema.Request(ListDesignersRequest.RequestName)
            .SupportsFilter()
            .SupportsSort()
            .SupportsLimit()
            .SupportsSkip()
            .SupportsCount()
            .ReturnsListOfObjects<Designer>(Configure);
    }

    /// <summary>Configures the fields of <see cref="Designer"/>.</summary>
    private static void Configure(IObjectTypeConfigBuilder<Designer> designer)
    {
        designer.SimpleField(it => it.Id)
            .HasName(Designer.IdPropertyName)
            .SupportsFilter(it => it.SupportsEqualityFilterFunctions())
            .SupportsSort();

        designer.SimpleField(it => it.Name)
            .HasName(Designer.NamePropertyName)
            .SupportsFilter(it => it.SupportsStringFilterFunctions())
            .SupportsSort(it => it.SupportsStringFieldFunctions());
    }
}