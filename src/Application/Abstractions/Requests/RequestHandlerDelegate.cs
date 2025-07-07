// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Application.Abstractions.Requests;

/// <summary>
/// The <see cref="IRequestHandler{TRequest,TResponse}.Handle"/> method defined as a delegate for use in a pipeline.
/// </summary>
/// <typeparam name="TRequest">The type of request to handle.</typeparam>
/// <typeparam name="TResponse">The type of response to return.</typeparam>
/// <param name="request">The request to handle.</param>
/// <param name="cancellationToken">A token to cancel the operation.</param>
/// <returns>Response for the given request.</returns>
public delegate Task<TResponse> RequestHandlerDelegate<in TRequest, TResponse>(
    TRequest request, 
    CancellationToken cancellationToken
) where TRequest : IRequest<TResponse>;