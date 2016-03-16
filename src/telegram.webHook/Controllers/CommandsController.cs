using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using telegram.webHook.Classes;
using Microsoft.Extensions.OptionsModel;
using telegram.webHook.Classes.Resources;

namespace telegram.webHook.Controllers
{
   
    public class CommandsController : Controller
    {

        private BotSettings settings { get; set; }

        public CommandsController(IOptions<BotSettings> s)
        {
            settings = s.Value;
        }


        [Route("init")]
        [HttpGet]
        public IActionResult InitHook(int id = 0)
        {

            string result = "Ok";

            Bot.GetApi(settings.ApiToken).SetWebhook("https://www.madeinitalyrussia.com:8443/WebHook").Wait();

            return Ok(result);

        }
        [Route("stop")]
        [HttpGet]
        public IActionResult Stop(int id = 0)
        {
           
            Bot.GetApi(settings.ApiToken).StopReceiving();
            string result = "Stop Ok";
            return Ok(result);

        }
        [Route("start")]
        [HttpGet]
        public IActionResult Start(int id = 0)
        {

            Bot.GetApi(settings.ApiToken).StartReceiving();
            string result = "Ok";
            return Ok(result);

        }
    }
}
