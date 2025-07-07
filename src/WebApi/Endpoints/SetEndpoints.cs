// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Application.Abstractions.Requests;
using FunQL.Playground.Application.Features.Sets.Models;
using FunQL.Playground.Application.Features.Sets.Requests.List;
using FunQL.Playground.WebApi.CustomResults;

namespace FunQL.Playground.WebApi.Endpoints;

/// <summary>Extensions to map the <c>/sets</c> endpoints.</summary>
public static class SetEndpoints
{
    /// <summary>Maps the <c>/sets</c> endpoints.</summary>
    /// <param name="app">Builder to map endpoints with.</param>
    public static void MapSetEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/sets");

        endpoints.MapGet("", ListSets);
    }

    /// <summary>Returns a list of all <see cref="Set"/> for given parameters.</summary>
    /// <param name="filter">Optional filter to apply.</param>
    /// <param name="sort">Optional sort to apply.</param>
    /// <param name="limit">Optional limit on the number of items returned.</param>
    /// <param name="skip">Optional number of items to skip.</param>
    /// <param name="count">Optional flag to include the total count of matching records.</param>
    /// <param name="dispatcher"><see cref="IDispatcher"/> to dispatch the request.</param>
    /// <param name="cancellationToken">Token to cancel async requests.</param>
    /// <returns>The <see cref="ResultsExtensions.OkListResponse{T}"/> with the list of <see cref="Set"/>.</returns>
    private static async Task<IResult> ListSets(
        string? filter,
        string? sort,
        string? limit,
        string? skip,
        string? count,
        IDispatcher dispatcher,
        CancellationToken cancellationToken
    )
    {
        var request = new ListSetsRequest(filter, sort, limit, skip, count);

        var result = await dispatcher.Send(request, cancellationToken);

        return Results.Extensions.OkListResponse(result);
    }
}