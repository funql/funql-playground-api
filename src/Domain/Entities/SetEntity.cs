// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using NodaTime;

namespace FunQL.Playground.Domain.Entities;

public class SetEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int SetNumber { get; set; }
    public int Pieces { get; set; }
    public double Price { get; set; }
    public Guid DesignerId { get; set; }
    public Instant LaunchTime { get; set; }
    public int PackagingTypeId { get; set; }
    public int ThemeId { get; set; }
    
    public DesignerEntity? Designer { get; set; }
    public ICollection<SetCategoryEntity> SetCategories { get; set; } = new HashSet<SetCategoryEntity>();
    public ICollection<SetItemNumberEntity> SetItemNumbers { get; set; } = new HashSet<SetItemNumberEntity>();
    public ICollection<SetMinifigureEntity> SetMinifigures { get; set; } = new HashSet<SetMinifigureEntity>();
}