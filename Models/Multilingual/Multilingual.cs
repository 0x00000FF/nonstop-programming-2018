using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NonstopCoding.Models.Multilingual
{
    public abstract class Multilingual
    {
        public const string TagTemplate = "<a href=\"https://twitter.com/{0}\" target=\"_blank\"><i class=\"fab fa-twitter mr-1\"></i>{1}</a>";

        public string GetUserTag(string id, string name) => string.Format(TagTemplate, id, name);

        // ----------------------------------------- //

        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string SubMessage { get; set; }

        public string Header { get; set; }

        public string Introduction_1 { get; set; }
        public string Introduction_2 { get; set; }
        public string Introduction_3 { get; set; }

        public string Contributor { get; set; }
        public string ContributionMessage { get; set; }
    }
}