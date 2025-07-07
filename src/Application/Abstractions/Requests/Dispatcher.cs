// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Collections.Concurrent;

namespace FunQL.Playground.Application.Abstractions.Requests;

/// <summary>Implementation of the dispatcher that uses <see cref="IServiceProvider"/> to handle the requests.</summary>
public class Dispatcher(
    IServiceProvider serviceProvider
) : IDispatcher
{
    /// <summary>Cached pipelines.</summary>
    private static readonly ConcurrentDictionary<Type, RequestPipelineBase> RequestPipelines = new();
    
    /// <summary>Provider to get the request handlers.</summary>
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
    /// <inheritdoc/>
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var handler = (RequestPipeline<TResponse>)RequestPipelines.GetOrAdd(request.GetType(), static requestType =>
        {
            var wrapperType = typeof(RequestPipelineImpl<,>).MakeGenericType(requestType, typeof(TResponse));
            var wrapper = Activator.CreateInstance(wrapperType) 
                ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}");
            return (RequestPipeline<TResponse>)wrapper;
        });

        return handler.Handle(request, _serviceProvider, cancellationToken);
    }
}