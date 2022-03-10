using BFTemplate.Model;
using BotFramework.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BFTemplate.Services;

public class TelegramContext : IdentityDbContext<User>
{
    public TelegramContext(DbContextOptions builder) : base(builder)
    {
    }
}