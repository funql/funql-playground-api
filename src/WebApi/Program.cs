using FunQL.Playground.WebApi.Startup;

WebApplication.CreateBuilder(args)
    .ConfigureBuilder()
    .Build()
    .ConfigureApp()
    .Run();