// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using Microsoft.Extensions.DependencyInjection;

namespace FunQL.Playground.Application.Abstractions.Requests;

/// <summary>Base class for request pipeline implementations.</summary>
public abstract class RequestPipelineBase
{
    /// <summary>Handles a request through the pipeline.</summary>
    /// <param name="request">The request to handle.</param>
    /// <param name="serviceProvider">The service provider for dependency resolution.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Response for the given request.</returns>
    public abstract Task<object?> Handle(
        IRequest<object> request,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    );
}

/// <summary>Base class for typed request pipeline implementations.</summary>
/// <typeparam name="TResponse">The type of response returned by the pipeline.</typeparam>
public abstract class RequestPipeline<TResponse> : RequestPipelineBase
{
    /// <summary>Handles a typed request through the pipeline.</summary>
    /// <param name="request">The request to handle.</param>
    /// <param name="serviceProvider">The service provider for dependency resolution.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Response for the given request.</returns>
    public abstract Task<TResponse> Handle(
        IRequest<TResponse> request, 
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    );
}

/// <summary>Implements the request pipeline for specific request and response types.</summary>
/// <typeparam name="TRequest">The type of request being handled.</typeparam>
/// <typeparam name="TResponse">The type of response being returned.</typeparam>
public class RequestPipelineImpl<TRequest, TResponse> : RequestPipeline<TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <inheritdoc />
    public override async Task<object?> Handle(
        IRequest<object> request, 
        IServiceProvider serviceProvider, 
        CancellationToken cancellationToken
    ) => await Handle((IRequest<TResponse>)request, serviceProvider, cancellationToken).ConfigureAwait(false);

    /// <inheritdoc />
    public override Task<TResponse> Handle(
        IRequest<TResponse> request, 
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    )
    {
        return serviceProvider
            .GetServices<IPipelineBehavior<TRequest, TResponse>>()
            .Reverse()
            .Aggregate(
                (RequestHandlerDelegate<TRequest, TResponse>)Handler,
                (next, behavior) => 
                    (req, ct) => behavior.Handle(req, next, ct)
            )
            .Invoke((TRequest) request, cancellationToken);

        Task<TResponse> Handler(TRequest req, CancellationToken ct) => 
            serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>()
                .Handle(req, ct);
    }
}