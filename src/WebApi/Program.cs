// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using FunQL.Playground.WebApi.Startup;

WebApplication.CreateBuilder(args)
    .ConfigureBuilder()
    .Build()
    .ConfigureApp()
    .Run();