// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Core.Requests.Nodes;
using FunQL.Playground.Application.Abstractions.Requests;
using FunQL.Playground.Application.Features.Designers.Models;

namespace FunQL.Playground.Application.Features.Designers.Requests.List;

/// <summary>Request to get a list of <see cref="Designer"/>.</summary>
public sealed record ListDesignersRequest(
    string? Filter,
    string? Sort,
    string? Limit,
    string? Skip,
    string? Count
) : IRequest<ListResponse<Designer>>
{
    /// <summary>Name of the request in FunQL.</summary>
    public const string RequestName = "listDesigners";
}