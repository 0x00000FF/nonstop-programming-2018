using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NonstopCoding.Models.Multilingual
{
    public class English : Multilingual
    {
        public English()
        {
            Title = "Nonstop Programming!";
            Subtitle = "24 hours of Nonstop Project in Christmas";
            SubMessage = "Don't get <b>away from keyboard</b> unless you are done!";

            Header = "What's this?";
            Introduction_1 = $"\"Nonstop Programming\" is a event that is held by {GetUserTag("0x00000FF", "PKnowledge(0x00000FF)")}. " +
                             $"All participants have to do is just code, for your project at Christmas! Primary objective is \"Finishing your project\". So keep typing, never get away from your keyboard!";
            Introduction_2 = "There are no requirements to participate! Let's code together!";
            Introduction_3 = "If you want to share your project with others, Feel free to post!";

            ContributionMessage = "If you want to fix error or submit translations, please DM to @0x00000FF!";
        }
    }
}
