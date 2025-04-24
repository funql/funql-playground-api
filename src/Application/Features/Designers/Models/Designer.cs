// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json.Serialization;

namespace FunQL.Playground.Application.Features.Designers.Models;

/// <summary>Data of a designer.</summary>
public sealed record Designer
{
    /// <summary>Property name of <see cref="Id"/>.</summary>
    public const string IdPropertyName = "id";
    /// <summary>Property name of <see cref="Name"/>.</summary>
    public const string NamePropertyName = "name";
    
    /// <summary>ID.</summary>
    [JsonPropertyName(IdPropertyName)]
    public required Guid Id { get; init; }
    /// <summary>Name.</summary>
    [JsonPropertyName(NamePropertyName)]
    public required string Name { get; init; }
}