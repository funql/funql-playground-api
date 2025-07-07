// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Application.Abstractions.Requests;

/// <summary>Defines a behavior that can be applied to the request processing pipeline.</summary>
/// <typeparam name="TRequest">The type of request being handled.</typeparam>
/// <typeparam name="TResponse">The type of response being returned.</typeparam>
public interface IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    /// <summary>Handles the request by applying the behavior and calling the next handler in the pipeline.</summary>
    /// <param name="request">The request being processed.</param>
    /// <param name="next">The delegate representing the next handler in the pipeline.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Response for the given request.</returns>
    Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TRequest, TResponse> next, 
        CancellationToken cancellationToken
    );
}