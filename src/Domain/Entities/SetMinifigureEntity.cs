// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Domain.Entities;

public class SetMinifigureEntity
{
    public Guid Id { get; set; }
    public Guid SetId { get; set; }
    public Guid MinifigureId { get; set; }
    public int Quantity { get; set; }
    
    public MinifigureEntity? Minifigure { get; set; }
}