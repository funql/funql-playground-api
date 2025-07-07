// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Collections.Concurrent;

namespace FunQL.Playground.Application.Abstractions.Requests;

public class Dispatcher(
    IServiceProvider serviceProvider
) : IDispatcher
{
    private static readonly ConcurrentDictionary<Type, RequestPipelineBase> RequestPipelines = new();
    
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
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