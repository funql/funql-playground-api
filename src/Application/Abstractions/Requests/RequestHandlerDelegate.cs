// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Application.Abstractions.Requests;

public delegate Task<TResponse> RequestHandlerDelegate<in TRequest, TResponse>(
    TRequest request, 
    CancellationToken cancellationToken
) where TRequest : IRequest<TResponse>;