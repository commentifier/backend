using System.Collections.Generic;
using Telegram.Bot;

namespace Commentifier.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
        List<int> MailReceiver { get; }
    }
}