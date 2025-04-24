// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json.Serialization;

namespace FunQL.Playground.Application.Features.Common.Models;

/// <summary>Different categories.</summary>
/// <remarks>Values must be equal to their corresponding 'id' in database.</remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Category
{
    /// <summary>Movies.</summary>
    [JsonStringEnumMemberName("MOVIES")] 
    Movies = 1,
    /// <summary>Vehicles.</summary>
    [JsonStringEnumMemberName("VEHICLES")] 
    Vehicles = 2,
    /// <summary>Ultimate collector series (UCS).</summary>
    [JsonStringEnumMemberName("ULTIMATE_COLLECTOR_SERIES")] 
    UltimateCollectorSeries = 3,
}