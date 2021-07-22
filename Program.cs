using BFTemplate.Services;
using BotFramework;
using BotFramework.Abstractions;
using BotFramework.Clients;
using BotFramework.HostServices;
using BotFramework.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Telegram.Bot;

namespace BFTemplate
{
    internal static class Program
    {
        private static void Main()
        {
            using var host = Host.CreateDefaultBuilder()
                .UseConfigurationWithEnvironment()
                .UseSerilog((context, configuration) =>
                {
                    configuration
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console();
                })
                .ConfigureApp((app, context) =>
                {
                    app.Services.AddSingleton<ITelegramBotClient>(_ => new TelegramBotClient(context.Configuration["BotToken"]));
                    app.Services.AddTransient<IUpdateConsumer, Client>();
                    app.Services.AddDbContext<TelegramContext>();

                    app.UseMiddleware<LoggingMiddleware>();
                    app.UseHandlers();
                    app.UseStaticCommands();
                })
                .Build()
                .RunAsync();
        }
    }
}
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