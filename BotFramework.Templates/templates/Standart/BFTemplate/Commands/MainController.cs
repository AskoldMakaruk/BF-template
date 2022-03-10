using System.Threading.Tasks;
using BFTemplate.Services;
using BotFramework.Abstractions;
using BotFramework.Extensions;
using BotFramework.Services.Commands;
using BotFramework.Services.Commands.Attributes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BFTemplate.Commands;

[Priority(EndpointPriority.First)]
public class MainController : CommandControllerBase
{
    private readonly ITelegramBotClient bot;
    private readonly TelegramContext context;

    public MainController(IClient client,
        UpdateContext update,
        ITelegramBotClient bot,
        TelegramContext context) : base(client, update)
    {
        this.bot = bot;
        this.context = context;
    }

    [Priority(EndpointPriority.First)]
    [StartsWith("/start")]
    public async Task Start()
    {
        await Client.SendTextMessage("This is BF-template. Find more examples at https://github.com/AskoldMakaruk/BotFramework/tree/dev/BotFramework.Examples");
    }
}