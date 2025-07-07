// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Core.Requests.Nodes;
using FunQL.Playground.Application.Abstractions.Requests;
using FunQL.Playground.Application.Features.Sets.Models;

namespace FunQL.Playground.Application.Features.Sets.Requests.List;

/// <summary>Request to get a list of <see cref="Set"/>.</summary>
public sealed record ListSetsRequest(
    string? Filter,
    string? Sort,
    string? Limit,
    string? Skip,
    string? Count
) : IRequest<ListResponse<Set>>
{
    /// <summary>Name of the request in FunQL.</summary>
    public const string RequestName = "listSets";
}