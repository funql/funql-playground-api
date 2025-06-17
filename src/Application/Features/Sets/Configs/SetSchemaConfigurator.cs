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
using FunQL.Playground.Application.Features.Sets.Models;
using FunQL.Playground.Application.Features.Sets.Requests.List;

namespace FunQL.Playground.Application.Features.Sets.Configs;

/// <summary>Configurator to configure the <c>Minifigure</c> requests.</summary>
public class SetSchemaConfigurator : ISchemaConfigurator
{
    /// <inheritdoc/>
    public void Configure(ISchemaConfigBuilder schema)
    {
        schema.Request(ListSetsRequest.RequestName)
            .SupportsFilter()
            .SupportsSort()
            .SupportsLimit()
            .SupportsSkip()
            .SupportsCount()
            .ReturnsListOfObjects<Set>(Configure);
    }

    /// <summary>Configures the fields of <see cref="Set"/>.</summary>
    private static void Configure(IObjectTypeConfigBuilder<Set> set)
    {
        set.SimpleField(it => it.Id)
            .HasName(Set.IdPropertyName)
            .SupportsFilter(it => it.SupportsEqualityFilterFunctions())
            .SupportsSort();

        set.SimpleField(it => it.Name)
            .HasName(Set.NamePropertyName)
            .SupportsFilter(it => it.SupportsStringFilterFunctions())
            .SupportsSort(it => it.SupportsStringFieldFunctions());

        set.SimpleField(it => it.SetNumber)
            .HasName(Set.SetNumberPropertyName)
            .SupportsFilter(it => it.SupportsComparisonFilterFunctions())
            .SupportsSort();

        set.SimpleField(it => it.ItemNumber)
            .HasName(Set.ItemNumberPropertyName);

        set.SimpleField(it => it.Pieces)
            .HasName(Set.PiecesPropertyName)
            .SupportsFilter(it => it.SupportsComparisonFilterFunctions())
            .SupportsSort();

        set.SimpleField(it => it.Price)
            .HasName(Set.PricePropertyName)
            .SupportsFilter(it => it.SupportsDoubleFilterFunctions())
            .SupportsSort(it => it.SupportsDoubleFieldFunctions());

        set.SimpleField(it => it.DesignerId)
            .HasName(Set.DesignerIdPropertyName)
            .SupportsFilter(it => it.SupportsEqualityFilterFunctions())
            .SupportsSort();

        set.ObjectField(it => it.Designer)
            .HasName(Set.DesignerPropertyName)
            .Configure(designer =>
            {
                designer.SimpleField(it => it.Id)
                    .HasName(Designer.IdPropertyName)
                    .SupportsFilter(it => it.SupportsEqualityFilterFunctions())
                    .SupportsSort();

                designer.SimpleField(it => it.Name)
                    .HasName(Designer.NamePropertyName)
                    .SupportsFilter(it => it.SupportsStringFilterFunctions())
                    .SupportsSort(it => it.SupportsStringFieldFunctions());
            });

        set.SimpleField(it => it.LaunchTime)
            .HasName(Set.LaunchTimePropertyName)
            .SupportsFilter(it => it
                .SupportsDateTimeFilterFunctions()
                // EFCore uses Npgsql, which does not support DateTime.Millisecond, so disable it
                .SupportsMillisecond(false)
            )
            .SupportsSort(it => it
                .SupportsDateTimeFieldFunctions()
                // EFCore uses Npgsql, which does not support DateTime.Millisecond, so disable it
                .SupportsMillisecond(false)
            );

        set.SimpleField(it => it.PackagingType)
            .HasName(Set.PackagingTypePropertyName)
            .SupportsFilter(it => it.SupportsEqualityFilterFunctions());

        set.SimpleField(it => it.Theme)
            .HasName(Set.ThemePropertyName)
            .SupportsFilter(it => it.SupportsEqualityFilterFunctions());

        set.ListField(it => it.Categories)
            .HasName(Set.CategoriesPropertyName)
            .Configure(it => it.SupportsFilter(f => f.SupportsAny().SupportsAll()))
            .SimpleItem()
            .Configure(category =>
            {
                category.SupportsFilter(it => it.SupportsEqualityFilterFunctions());
            });

        set.ListField(it => it.Minifigures)
            .HasName(Set.MinifiguresPropertyName)
            .Configure(it => it.SupportsFilter(f => f.SupportsAny().SupportsAll()))
            .ObjectItem()
            .Configure(minifigure =>
            {
                minifigure.SimpleField(it => it.Id)
                    .HasName(SetMinifigure.IdPropertyName)
                    .SupportsFilter(it => it.SupportsEqualityFilterFunctions());

                minifigure.SimpleField(it => it.Name)
                    .HasName(SetMinifigure.NamePropertyName)
                    .SupportsFilter(it => it.SupportsStringFilterFunctions());

                minifigure.SimpleField(it => it.Quantity)
                    .HasName(SetMinifigure.QuantityPropertyName)
                    .SupportsFilter(it => it.SupportsComparisonFilterFunctions());
            });
    }
}