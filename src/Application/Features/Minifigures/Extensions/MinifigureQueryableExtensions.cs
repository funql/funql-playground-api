// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Application.Features.Minifigures.Models;
using FunQL.Playground.Domain.Entities;

namespace FunQL.Playground.Application.Features.Minifigures.Extensions;

/// <summary>Extensions for <see cref="IQueryable{T}"/> related to <see cref="Minifigure"/>.</summary>
public static class MinifigureQueryableExtensions
{
    /// <summary>Maps <see cref="MinifigureEntity"/> to <see cref="Minifigure"/>.</summary>
    /// <param name="queryable">Queryable to map.</param>
    /// <returns>Queryable of <see cref="Minifigure"/>.</returns>
    public static IQueryable<Minifigure> MapToMinifigure(
        this IQueryable<MinifigureEntity> queryable
    ) => queryable.Select(from => new Minifigure
    {
        Id = from.Id,
        Name = from.Name,
    });
}