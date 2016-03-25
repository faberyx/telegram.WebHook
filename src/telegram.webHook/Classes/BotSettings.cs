using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telegram.webHook.Classes
{
    public class BotSettings
    {
        public string ApiToken { get; set; }
        public string DictionariesPath {get;set;}
        public string ResourcesPath { get; set; }

        public string WebSiteFbot { get; set; }
    }
}
