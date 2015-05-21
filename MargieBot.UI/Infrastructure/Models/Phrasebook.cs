using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargieBot.UI.Infrastructure.Models
{
    public class Phrasebook
    {
        public string GetQuery()
        {
            string[] queries = new string[] {
                "You rang?",
                "I sensed you have need of me.",
                "...",
                "Can I... assist you?"
            };

            return queries[new Random().Next(queries.Length)];
        }

        public string GetSlackbotSalutation()
        {
            string[] salutations = new string[] {
                "What manner of creature is this?",
                "Speak not in my presence, pitiful bot.",
                "Mornin', Slackbot! Heard you were out with Rita Bot last night. How'd it go?",
                "Well, howdy, Slackbot. You're lookin' mighty handsome today."
            };

            return salutations[new Random().Next(salutations.Length)];
        }

        public string GetYoureWelcome()
        {
            string[] youreWelcomes = new string[] {
                "I bear you no ill will... this time.",
                "Hmph.",
                "Aren't we clever?"
            };

            return youreWelcomes[new Random().Next(youreWelcomes.Length)];
        }
    }
}
