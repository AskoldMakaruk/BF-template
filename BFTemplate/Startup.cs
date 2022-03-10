using BFTemplate.Model;
using BFTemplate.Services;
using BotFramework.Abstractions;
using BotFramework.Identity;
using BotFramework.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BFTemplate;

public static class Startup
{
    public static void Configure(IAppBuilder app, HostBuilderContext context)
    {
        app.Services.AddDbContext<TelegramContext>(
            builder => builder.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnection")));

        app.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<TelegramContext>();
    }
}