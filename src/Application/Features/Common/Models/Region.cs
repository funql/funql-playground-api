// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json.Serialization;

namespace FunQL.Playground.Application.Features.Common.Models;

/// <summary>Different regions.</summary>
/// <remarks>Values must be equal to their corresponding 'id' in database.</remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Region
{
    /// <summary>Europe.</summary>
    [JsonStringEnumMemberName("EUROPE")] 
    Europe = 1,
    /// <summary>North America.</summary>
    [JsonStringEnumMemberName("NORTH_AMERICA")] 
    NorthAmerica = 2,
}