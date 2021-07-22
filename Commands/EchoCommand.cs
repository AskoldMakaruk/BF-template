using System.Threading.Tasks;
using BotFramework.Abstractions;
using BotFramework.Clients.ClientExtensions;
using Telegram.Bot.Types;

namespace BFTemplate.Commands
{
    public class EchoCommand : IStaticCommand
    {
        public async Task Execute(IClient client)
        {
            var message = await client.GetTextMessage();
            await client.SendTextMessage(message.Text);
        }

        public bool SuitableFirst(Update update)
        {
            return true;
        }
    }
}