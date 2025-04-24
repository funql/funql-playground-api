// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Text.Json.Serialization;

namespace FunQL.Playground.Application.Features.Common.Models;

/// <summary>Different themes.</summary>
/// <remarks>Values must be equal to their corresponding 'id' in database.</remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Theme
{
    /// <summary>Batman.</summary>
    [JsonStringEnumMemberName("BATMAN")] 
    Batman = 1,
    /// <summary>City.</summary>
    [JsonStringEnumMemberName("CITY")] 
    City = 2,
    /// <summary>Classic.</summary>
    [JsonStringEnumMemberName("CLASSIC")] 
    Classic = 3,
    /// <summary>Harry Potter.</summary>
    [JsonStringEnumMemberName("HARRY_POTTER")] 
    HarryPotter = 4,
    /// <summary>Icons.</summary>
    [JsonStringEnumMemberName("ICONS")] 
    Icons = 5,
    /// <summary>Ideas.</summary>
    [JsonStringEnumMemberName("IDEAS")] 
    Ideas = 6,
    /// <summary>Lord of the Rings.</summary>
    [JsonStringEnumMemberName("LORD_OF_THE_RINGS")] 
    LordOfTheRings = 7,
    /// <summary>Marvel.</summary>
    [JsonStringEnumMemberName("MARVEL")] 
    Marvel = 8,
    /// <summary>Star Wars.</summary>
    [JsonStringEnumMemberName("STAR_WARS")] 
    StarWars = 9,
    /// <summary>Technic.</summary>
    [JsonStringEnumMemberName("TECHNIC")] 
    Technic = 10,
}