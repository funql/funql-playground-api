// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json.Serialization;

namespace FunQL.Playground.Application.Features.Sets.Models;

/// <summary>Data of a set minifigure.</summary>
public sealed record SetMinifigure
{
    /// <summary>Property name of <see cref="Id"/>.</summary>
    public const string IdPropertyName = "id";
    /// <summary>Property name of <see cref="Name"/>.</summary>
    public const string NamePropertyName = "name";
    /// <summary>Property name of <see cref="Quantity"/>.</summary>
    public const string QuantityPropertyName = "quantity";
    
    /// <summary>ID.</summary>
    [JsonPropertyName(IdPropertyName)]
    public required Guid Id { get; init; }
    /// <summary>Name.</summary>
    [JsonPropertyName(NamePropertyName)]
    public required string Name { get; init; }
    /// <summary>Quantity.</summary>
    [JsonPropertyName(QuantityPropertyName)]
    public required int Quantity { get; init; }
}