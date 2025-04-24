// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

namespace FunQL.Playground.Domain.Entities;

public class SetItemNumberEntity
{
    public Guid Id { get; set; }
    public Guid SetId { get; set; }
    public int RegionId { get; set; }
    public int ItemNumber { get; set; }
}