using System;
using System.Collections.Generic;
using MargieBot.Models;

namespace MargieBot.Responders
{
    public class SimpleResponder : IResponder
    {
        public Func<SlackMessage, bool> CanRespondFunction { get; set; }
        public List<Func<SlackMessage, BotMessage>> GetResponseFunctions { get; set; }

        public SimpleResponder()
        {
            GetResponseFunctions = new List<Func<SlackMessage, BotMessage>>();
        }

        public bool CanRespond(SlackMessage context)
        {
            return CanRespondFunction(context);
        }

        public BotMessage GetResponse(SlackMessage context)
        {
            if (GetResponseFunctions.Count == 0) {
                throw new InvalidOperationException("Attempted to get a response for \"" + context.Message.Text + "\", but no valid responses have been registered.");
            }

            return GetResponseFunctions[new Random().Next(GetResponseFunctions.Count - 1)](context);
        }
    }
}