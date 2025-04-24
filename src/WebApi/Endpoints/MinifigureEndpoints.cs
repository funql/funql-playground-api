// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Application.Features.Minifigures.Models;
using FunQL.Playground.Application.Features.Minifigures.Requests.List;
using FunQL.Playground.WebApi.CustomResults;
using MediatR;

namespace FunQL.Playground.WebApi.Endpoints;

/// <summary>Extensions to map the <c>/minifigures</c> endpoints.</summary>
public static class MinifigureEndpoints
{
    /// <summary>Maps the <c>/minifigures</c> endpoints.</summary>
    /// <param name="app">Builder to map endpoints with.</param>
    public static void MapMinifigureEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/minifigures");

        endpoints.MapGet("", ListMinifigures);
    }

    /// <summary>Returns a list of all <see cref="Minifigure"/> for given parameters.</summary>
    /// <param name="filter">Optional filter to apply.</param>
    /// <param name="sort">Optional sort to apply.</param>
    /// <param name="limit">Optional limit on the number of items returned.</param>
    /// <param name="skip">Optional number of items to skip.</param>
    /// <param name="count">Optional flag to include the total count of matching records.</param>
    /// <param name="sender"><see cref="ISender"/> to use for sending the request via <see cref="MediatR"/>.</param>
    /// <returns>
    /// The <see cref="ResultsExtensions.OkListResponse{T}"/> with the list of <see cref="Minifigure"/>.
    /// </returns>
    private static async Task<IResult> ListMinifigures(
        string? filter,
        string? sort,
        string? limit,
        string? skip,
        string? count,
        ISender sender
    )
    {
        var request = new ListMinifiguresRequest(filter, sort, limit, skip, count);

        var result = await sender.Send(request);

        return Results.Extensions.OkListResponse(result);
    }
}