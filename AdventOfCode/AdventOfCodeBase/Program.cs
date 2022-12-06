using AdventOfCode.Shared.Intf;
using AdventOfCode2022;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddScoped<ISolve, SolveDay01>();
        services.AddScoped<ISolve, SolveDay02>();
        services.AddScoped<ISolve, SolveDay03>();
        services.AddScoped<ISolve, SolveDay04>();
        services.AddScoped<ISolve, SolveDay05>();
        services.AddScoped<ISolve, SolveDay06>();

    }).Build();

ExemplifyScoping(host.Services, "Scope 1");

await host.RunAsync();

static void ExemplifyScoping(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var allDays = provider.GetServices<ISolve>();

    foreach (var day in allDays)
    {
        Console.WriteLine($"--------------- Start Puzzle {day.GetType().Name} ---------------\r\n");
        day.SolvePartOne();
        Console.WriteLine($"--------------- BREAK ---------------\r\n");
        day.SolvePartTwo();
        Console.WriteLine($"--------------- End Puzzle {day.GetType().Name} ---------------\r\n");
    }
}