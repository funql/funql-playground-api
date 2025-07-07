// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using Microsoft.Extensions.DependencyInjection;

namespace FunQL.Playground.Application.Abstractions.Requests;

public abstract class RequestPipelineBase
{
    public abstract Task<object?> Handle(
        IRequest<object> request,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    );
}


public abstract class RequestPipeline<TResponse> : RequestPipelineBase
{
    public abstract Task<TResponse> Handle(
        IRequest<TResponse> request, 
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    );
}

public class RequestPipelineImpl<TRequest, TResponse> : RequestPipeline<TResponse>
    where TRequest : IRequest<TResponse>
{
    public override async Task<object?> Handle(
        IRequest<object> request, 
        IServiceProvider serviceProvider, 
        CancellationToken cancellationToken
    ) => await Handle((IRequest<TResponse>)request, serviceProvider, cancellationToken).ConfigureAwait(false);

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