// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Core.Requests.Nodes;
using FunQL.Linq.Schemas.Extensions;
using FunQL.Playground.Application.Abstractions.Requests;
using FunQL.Playground.Application.Features.Sets.Extensions;
using FunQL.Playground.Application.Features.Sets.Models;
using FunQL.Playground.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunQL.Playground.Application.Features.Sets.Requests.List;

/// <summary>Request handler for the <see cref="ListSetsRequest"/>.</summary>
public class ListSetsRequestHandler : IRequestHandler<ListSetsRequest, ListResponse<Set>>
{
    /// <summary>Context to access entities.</summary>
    private readonly IApiContext _context;
    /// <summary>Schema of the API.</summary>
    private readonly ApiSchema _apiSchema;

    /// <summary>Initializes properties.</summary>
    public ListSetsRequestHandler(IApiContext context, ApiSchema apiSchema)
    {
        _context = context;
        _apiSchema = apiSchema;
    }

    /// <inheritdoc/>
    public async Task<ListResponse<Set>> Handle(
        ListSetsRequest request,
        CancellationToken cancellationToken
    )
    {
        var (filter, sort, limit, skip, count) = request;
        
        return await _context.Sets
            .AsNoTracking()
            .MapToSet()
            .ExecuteRequestForParameters(
                _apiSchema.SchemaConfig, 
                ListSetsRequest.RequestName,
                filter: filter, 
                sort: sort,
                skip: skip,
                limit: limit,
                count: count,
                cancellationToken: cancellationToken
            ); 
    }
}