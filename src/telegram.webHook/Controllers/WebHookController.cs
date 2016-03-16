using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Telegram.Bot.Types;
using System.Text.RegularExpressions;
using telegram.webHook.Classes.Commands;
using telegram.webHook.Classes;
using Microsoft.Extensions.OptionsModel;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace telegram.webHook.Controllers
{
     
    public class WebHookController : Controller
    {
        private BotSettings settings { get; set; }

        public WebHookController(IOptions<BotSettings> s)
        {
            settings = s.Value;
        }



        [HttpPost]
        [Route("WebHook")]
        public async Task<IActionResult> Post([FromBody]Update update)
        {

            string[] banned = new Classes.Resources.LoadDictionary().Load(settings.DictionariesPath + "banned"); // "181127552"

            var message = update.Message;
            
            if (message.Type == MessageType.TextMessage && !banned.Contains(update.Message.From.Id.ToString()))
            {

                var match = Regex.Match(update.Message.Text + " ", @"(?'command'^\/.*?\s)?(?'action'.*?\s)?(?'pattern'.*)");

                if (match.Groups.Count > 1)
                {
                   
                    BotCommandFactory factory = new BotCommandFactory();
                    var command = factory.CreateCommand(match.Groups["command"].Value.Trim());
                    if (command == null)
                        await Bot.GetApi(settings.ApiToken).SendTextMessage(update.Message.Chat.Id, string.Format("...idiota.. devi aver scritto qualche cazzata.. {0}", update.Message.From.FirstName));
                    else
                    {
                        command.settings = settings;
                        command.BotApi = Bot.GetApi(settings.ApiToken);
                        await command.Process(update.Message, match);
                    }
                }
            }


            return Ok();
        }
    }
}
