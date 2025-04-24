// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Infrastructure;

/// <summary>Configuration for <see cref="Infrastructure"/>.</summary>
public sealed class InfrastructureOptions
{
    /// <summary>Key for the field in a settings file.</summary>
    public const string Infrastructure = "Infrastructure";
    
    /// <summary>Connection string for the database.</summary>
    public string ConnectionString { get; set; } = string.Empty;
}