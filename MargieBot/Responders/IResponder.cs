using MargieBot.Models;

namespace MargieBot.Responders
{
    public interface IResponder
    {
        bool CanRespond(SlackMessage context);
        BotMessage GetResponse(SlackMessage context);
    }
}