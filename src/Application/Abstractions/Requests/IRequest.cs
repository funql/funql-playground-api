// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Application.Abstractions.Requests;

/// <summary>Defines a request that returns a response of type <typeparamref name="TResponse"/>.</summary>
/// <typeparam name="TResponse">The type of response returned by the request.</typeparam>
public interface IRequest<out TResponse>;