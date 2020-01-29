using BotFramework.Bot;
using Serilog;

namespace BFTemplate
{
    class Program
    {
        static void Main()
        {
            new BotBuilder()
            .UseAssembly(typeof(Program).Assembly)
            .WithName("EchoBot")
            .WithToken("<YOURTOKEN>")
            .UseLogger(new LoggerConfiguration()
                       .MinimumLevel.Debug()
                       .WriteTo.Console()
                       .CreateLogger())
            .Build()
            .Run();
        }
    }
}