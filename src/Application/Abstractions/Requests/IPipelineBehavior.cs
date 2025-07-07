// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Application.Abstractions.Requests;

public interface IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TRequest, TResponse> next, 
        CancellationToken cancellationToken
    );
}