// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.Application.Features.Common.Models;
using FunQL.Playground.Application.Features.Designers.Models;
using FunQL.Playground.Application.Features.Sets.Models;
using FunQL.Playground.Domain.Entities;

namespace FunQL.Playground.Application.Features.Sets.Extensions;

/// <summary>Extensions for <see cref="IQueryable{T}"/> related to <see cref="Set"/>.</summary>
public static class SetQueryableExtensions
{
    /// <summary>Maps <see cref="SetEntity"/> to <see cref="Set"/>.</summary>
    /// <param name="queryable">Queryable to map.</param>
    /// <returns>Queryable of <see cref="Set"/>.</returns>
    public static IQueryable<Set> MapToSet(
        this IQueryable<SetEntity> queryable
    ) => queryable.Select(from => new Set
    {
        Id = from.Id,
        Name = from.Name,
        SetNumber = from.SetNumber,
        ItemNumber = new Dictionary<Region, int>(
            from.SetItemNumbers
                .Select(it => new KeyValuePair<Region, int>(
                    (Region)it.RegionId,
                    it.ItemNumber
                ))
        ),
        Pieces = from.Pieces,
        Price = from.Price,
        DesignerId = from.DesignerId,
        Designer = new Designer
        {
            Id = from.DesignerId,
            Name = from.Designer!.Name,
        },
        LaunchTime = from.LaunchTime,
        PackagingType = (PackagingType)from.PackagingTypeId,
        Theme = (Theme)from.ThemeId,
        Categories = from.SetCategories
            .Select(it => (Category)it.CategoryId),
        Minifigures = from.SetMinifigures
            .Select(it => new SetMinifigure
            {
                Id = it.Id,
                Name = it.Minifigure!.Name,
                Quantity = it.Quantity,
            })
    });
}