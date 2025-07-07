// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Core.Requests.Nodes;
using FunQL.Playground.Application.Abstractions.Requests;
using FunQL.Playground.Application.Features.Minifigures.Models;

namespace FunQL.Playground.Application.Features.Minifigures.Requests.List;

/// <summary>Request to get a list of <see cref="Minifigure"/>.</summary>
public sealed record ListMinifiguresRequest(
    string? Filter,
    string? Sort,
    string? Limit,
    string? Skip,
    string? Count
) : IRequest<ListResponse<Minifigure>>
{
    /// <summary>Name of the request in FunQL.</summary>
    public const string RequestName = "listMinifigures";
}