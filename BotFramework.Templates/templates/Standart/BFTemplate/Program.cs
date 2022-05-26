using System;
using System.Collections.Generic;
using BFTemplate.Services;
using BotFramework.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Telegram.Bot;
using Telegram.Bot.Types;

var host = Host.CreateDefaultBuilder()
    .UseConfigurationWithEnvironment()
    .UseSerilog((context, configuration) =>
    {
        configuration
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console();
    })
    .UseSimpleBotFramework()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        var env = hostingContext.HostingEnvironment;
        Console.WriteLine(env.EnvironmentName);
    });
    .Build(Startup.Configure);

var context = host.Services.GetService<TelegramContext>()!;
context.Database.Migrate();

var bot = host.Services.GetService<ITelegramBotClient>()!;
await bot.SetMyCommandsAsync(new List<BotCommand>
{
    new()
    {
        Command = "/start",
        Description = "старт ураа!"
    },
});

host.Run();

/*
 * amazing guide about webhooks
 * https://core.telegram.org/bots/webhooks
 *
 * Useful commands:
 * -Efcore:
 * -- dotnet ef migrations add initial
 * -- dotnet ef database update
 *
 * Packages
 * dotnet add package Microsoft.EntityFrameworkCore.Tools
 * dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
 * dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design  
 */