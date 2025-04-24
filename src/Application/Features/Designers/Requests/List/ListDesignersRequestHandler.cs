// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Core.Requests.Nodes;
using FunQL.Linq.Schemas.Extensions;
using FunQL.Playground.Application.Features.Designers.Extensions;
using FunQL.Playground.Application.Features.Designers.Models;
using FunQL.Playground.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FunQL.Playground.Application.Features.Designers.Requests.List;

/// <summary>Request handler for the <see cref="ListDesignersRequest"/>.</summary>
public class ListDesignersRequestHandler : IRequestHandler<ListDesignersRequest, ListResponse<Designer>>
{
    /// <summary>Context to access entities.</summary>
    private readonly IApiContext _context;
    /// <summary>Schema of the API.</summary>
    private readonly ApiSchema _apiSchema;

    /// <summary>Initializes properties.</summary>
    public ListDesignersRequestHandler(IApiContext context, ApiSchema apiSchema)
    {
        _context = context;
        _apiSchema = apiSchema;
    }

    /// <inheritdoc/>
    public async Task<ListResponse<Designer>> Handle(
        ListDesignersRequest request,
        CancellationToken cancellationToken
    )
    {
        var (filter, sort, limit, skip, count) = request;
        
        return await _context.Designers
            .AsNoTracking()
            .MapToDesigner()
            .ExecuteRequestForParameters(
                _apiSchema.SchemaConfig, 
                ListDesignersRequest.RequestName,
                filter: filter, 
                sort: sort,
                skip: skip,
                limit: limit,
                count: count,
                cancellationToken: cancellationToken
            ); 
    }
}