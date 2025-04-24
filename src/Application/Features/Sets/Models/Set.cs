// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json.Serialization;
using FunQL.Playground.Application.Features.Common.Models;
using FunQL.Playground.Application.Features.Designers.Models;
using NodaTime;

namespace FunQL.Playground.Application.Features.Sets.Models;

/// <summary>Data of a set.</summary>
public sealed record Set
{
    /// <summary>Property name of <see cref="Id"/>.</summary>
    public const string IdPropertyName = "id";
    /// <summary>Property name of <see cref="Name"/>.</summary>
    public const string NamePropertyName = "name";
    /// <summary>Property name of <see cref="SetNumber"/>.</summary>
    public const string SetNumberPropertyName = "setNumber";
    /// <summary>Property name of <see cref="ItemNumber"/>.</summary>
    public const string ItemNumberPropertyName = "itemNumber";
    /// <summary>Property name of <see cref="Pieces"/>.</summary>
    public const string PiecesPropertyName = "pieces";
    /// <summary>Property name of <see cref="Price"/>.</summary>
    public const string PricePropertyName = "price";
    /// <summary>Property name of <see cref="DesignerId"/>.</summary>
    public const string DesignerIdPropertyName = "designerId";
    /// <summary>Property name of <see cref="Designer"/>.</summary>
    public const string DesignerPropertyName = "designer";
    /// <summary>Property name of <see cref="LaunchTime"/>.</summary>
    public const string LaunchTimePropertyName = "launchTime";
    /// <summary>Property name of <see cref="PackagingType"/>.</summary>
    public const string PackagingTypePropertyName = "packagingType";
    /// <summary>Property name of <see cref="Theme"/>.</summary>
    public const string ThemePropertyName = "theme";
    /// <summary>Property name of <see cref="Categories"/>.</summary>
    public const string CategoriesPropertyName = "categories";
    /// <summary>Property name of <see cref="Minifigures"/>.</summary>
    public const string MinifiguresPropertyName = "minifigures";
    
    /// <summary>ID.</summary>
    [JsonPropertyName(IdPropertyName)]
    public required Guid Id { get; init; }
    /// <summary>Name.</summary>
    [JsonPropertyName(NamePropertyName)]
    public required string Name { get; init; }
    /// <summary>Set number.</summary>
    [JsonPropertyName(SetNumberPropertyName)]
    public required int SetNumber { get; init; }
    /// <summary>Item number per region.</summary>
    [JsonPropertyName(ItemNumberPropertyName)]
    public required IDictionary<Region, int> ItemNumber { get; init; }
    /// <summary>Pieces.</summary>
    [JsonPropertyName(PiecesPropertyName)]
    public required int Pieces { get; init; }
    /// <summary>Price.</summary>
    [JsonPropertyName(PricePropertyName)]
    public required double Price { get; init; }
    /// <summary>Designer ID.</summary>
    [JsonPropertyName(DesignerIdPropertyName)]
    public required Guid DesignerId { get; init; }
    /// <summary>Designer.</summary>
    [JsonPropertyName(DesignerPropertyName)]
    public required Designer Designer { get; init; }
    /// <summary>Launch time.</summary>
    [JsonPropertyName(LaunchTimePropertyName)]
    public required Instant LaunchTime { get; init; }
    /// <summary>Packaging type.</summary>
    [JsonPropertyName(PackagingTypePropertyName)]
    public required PackagingType PackagingType { get; init; }
    /// <summary>Theme.</summary>
    [JsonPropertyName(ThemePropertyName)]
    public required Theme Theme { get; init; }
    /// <summary>Categories.</summary>
    [JsonPropertyName(CategoriesPropertyName)]
    public required IEnumerable<Category> Categories { get; init; }
    /// <summary>Minifigures.</summary>
    [JsonPropertyName(MinifiguresPropertyName)]
    public required IEnumerable<SetMinifigure> Minifigures { get; init; }
}