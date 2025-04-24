// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json.Serialization;

namespace FunQL.Playground.Application.Features.Common.Models;

/// <summary>Different packaging types.</summary>
/// <remarks>Values must be equal to their corresponding 'id' in database.</remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PackagingType
{
    /// <summary>Box.</summary>
    [JsonStringEnumMemberName("BOX")] 
    Box = 1,
    /// <summary>Polybag.</summary>
    [JsonStringEnumMemberName("POLYBAG")] 
    Polybag = 2,
}