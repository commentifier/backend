using Telegram.Bot.Types;

namespace Commentifier.Services
{
    public interface IUpdateService
    {
        void Echo(Update update);
    }
}
