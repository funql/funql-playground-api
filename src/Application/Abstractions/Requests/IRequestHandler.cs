// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Application.Abstractions.Requests;

/// <summary>
/// Defines a handler for processing a specific <see cref="IRequest{TResponse}"/> and returning its response.
/// </summary>
/// <typeparam name="TRequest">The type of request to handle.</typeparam>
/// <typeparam name="TResponse">The type of response to return.</typeparam>
public interface IRequestHandler<in TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    /// <summary>Handles the given request.</summary>
    /// <param name="request">The request to handle.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Response for the given request.</returns>
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}