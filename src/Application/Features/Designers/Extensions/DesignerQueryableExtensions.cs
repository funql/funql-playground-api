// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Application.Features.Designers.Models;
using FunQL.Playground.Domain.Entities;

namespace FunQL.Playground.Application.Features.Designers.Extensions;

/// <summary>Extensions for <see cref="IQueryable{T}"/> related to <see cref="Designer"/>.</summary>
public static class DesignerQueryableExtensions
{
    /// <summary>Maps <see cref="DesignerEntity"/> to <see cref="Designer"/>.</summary>
    /// <param name="queryable">Queryable to map.</param>
    /// <returns>Queryable of <see cref="Designer"/>.</returns>
    public static IQueryable<Designer> MapToDesigner(
        this IQueryable<DesignerEntity> queryable
    ) => queryable.Select(from => new Designer
    {
        Id = from.Id,
        Name = from.Name,
    });
}