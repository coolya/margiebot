﻿using System;
using System.Reflection;
using System.Text.RegularExpressions;
using MargieBot.MessageProcessors;
using MargieBot.Models;

namespace MargieBot.UI.Infrastructure.BotResponseProcessors
{
    public class WhatsNewResponseProcessor : IResponseProcessor
    {
        public bool CanRespond(ResponseContext context)
        {
            return context.Message.MentionsBot && Regex.IsMatch(context.Message.Text, @"\b(what's new)\b", RegexOptions.IgnoreCase);
        }

        public string GetResponse(ResponseContext context)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            return
                @"I'm " + context.BotUserName + " v." +
                version.Major.ToString() + "." +
                version.Minor.ToString() + "." +
                version.Build.ToString() + "! Here's what all's been goin' on with me lately.```" +
                "- I'm learnin' to roll dice because I have a crush on this nerdy bot who plays RPGs downtown. Ask me to roll 4d6 sometime!\n" +
                "- I'm an internet phenomenon now, y'all! You can learn more about me and how I work on github at https://github.com/jammerware/margiebot/wiki and even view my source! Y'all be gentlemen and ladies now. I'm a complicated gal!\n" +
                "```";
        }
    }
}