// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Core.Requests.Nodes;
using FunQL.Linq.Schemas.Extensions;
using FunQL.Playground.Application.Features.Minifigures.Extensions;
using FunQL.Playground.Application.Features.Minifigures.Models;
using FunQL.Playground.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FunQL.Playground.Application.Features.Minifigures.Requests.List;

/// <summary>Request handler for the <see cref="ListMinifiguresRequest"/>.</summary>
public class ListMinifiguresRequestHandler : IRequestHandler<ListMinifiguresRequest, ListResponse<Minifigure>>
{
    /// <summary>Context to access entities.</summary>
    private readonly IApiContext _context;
    /// <summary>Schema of the API.</summary>
    private readonly ApiSchema _apiSchema;

    /// <summary>Initializes properties.</summary>
    public ListMinifiguresRequestHandler(IApiContext context, ApiSchema apiSchema)
    {
        _context = context;
        _apiSchema = apiSchema;
    }

    /// <inheritdoc/>
    public async Task<ListResponse<Minifigure>> Handle(
        ListMinifiguresRequest request,
        CancellationToken cancellationToken
    )
    {
        var (filter, sort, limit, skip, count) = request;
        
        return await _context.Minifigures
            .AsNoTracking()
            .MapToMinifigure()
            .ExecuteRequestForParameters(
                _apiSchema.SchemaConfig, 
                ListMinifiguresRequest.RequestName,
                filter: filter, 
                sort: sort,
                skip: skip,
                limit: limit,
                count: count,
                cancellationToken: cancellationToken
            ); 
    }
}