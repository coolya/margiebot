using System;
using System.Text;
using System.Text.RegularExpressions;
using MargieBot.MessageProcessors;
using MargieBot.Models;
using MargieBot.UI.Infrastructure.Models;
using MargieBot.UI.Infrastructure.Models.DnD;

namespace MargieBot.UI.Infrastructure.BotResponseProcessors.DnDResponseProcessors
{
    public class RollResponseProcessor : IResponseProcessor
    {
        private const string DICE_REGEX = @"(?<NumberOfDice>[0-9]+)d(?<NumberOfSides>[1-9][0-9]*)";

        public bool CanRespond(ResponseContext context)
        {
            return (context.Message.MentionsBot || context.Message.ChatHub.Type == SlackChatHubType.DM) && Regex.IsMatch(context.Message.Text, @"\broll\b", RegexOptions.IgnoreCase) && Regex.IsMatch(context.Message.Text, DICE_REGEX, RegexOptions.IgnoreCase);
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            StringBuilder builder = new StringBuilder("I prepare for battle... I only pray that it has prepared for me.\n\n`");
            int runningTotal = 0;
            bool conversionFailed = false;

            foreach (Match match in Regex.Matches(context.Message.Text, DICE_REGEX)) {
                int numberOfDice = 0;
                try {
                    numberOfDice = Convert.ToInt32(match.Groups["NumberOfDice"].Value);
                }
                catch (Exception) {
                    conversionFailed = true;
                    break;
                }

                if (numberOfDice > 100) {
                    conversionFailed = true;
                }

                Die die = new Die();
                try {
                    die.NumberOfSides = Convert.ToInt32(match.Groups["NumberOfSides"].Value);
                }
                catch(Exception) {
                    conversionFailed = true;
                    break;
                }

                if (numberOfDice > 1) {
                    builder.Append("(");
                }

                for (int i = 0; i < numberOfDice; i++) {
                    if (i > 0) {
                        builder.Append(" + ");
                    }

                    int thisRoll = die.Roll();
                    runningTotal += thisRoll;

                    builder.Append(thisRoll.ToString());
                }

                if (numberOfDice > 1) {
                    builder.Append(")");
                }
            }

            builder.Append("`\n\n");
            builder.Append("I rolled " + runningTotal.ToString() + ". Does it bring me closer to the Betrayer?");

            if (!conversionFailed && builder.Length > 0) {
                return new BotMessage() { Text = builder.ToString() };
            }
            else {
                return new BotMessage() { Text = "*snort...* More trickery?" };
            }
        }
    }
}