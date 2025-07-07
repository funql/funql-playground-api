// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Application.Abstractions.Requests;

/// <summary>
/// Defines a dispatcher that dispatches <see cref="IRequest{TResponse}"/> to their corresponding
/// <see cref="IRequestHandler{TRequest,TResponse}"/>.
/// </summary>
public interface IDispatcher
{
    /// <summary>
    /// Sends the <paramref name="request"/> to its corresponding <see cref="IRequestHandler{TRequest,TResponse}"/>.
    /// </summary>
    /// <typeparam name="TResponse">The type of response expected from the request.</typeparam>
    /// <param name="request">The request to be processed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Response for the given request.</returns>
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}