// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Domain.Entities;

public class SetCategoryEntity
{
    public Guid Id { get; set; }
    public Guid SetId { get; set; }
    public int CategoryId { get; set; }
}