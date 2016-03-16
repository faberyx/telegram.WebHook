using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using telegram.webHook.Classes.Commands;
using telegram.webHook.Classes.Resources;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace telegram.webHook.Classes.Bots
{
    public class InsultaBot : IBotCommand
    {

        private LoadDictionary dictionary = new LoadDictionary();
        private LoadResource resource = new LoadResource();

        public BotSettings settings { get; set; }

        public Api BotApi { get; set; }

        public async Task Process(Message message, Match messageMatches)
        {
            try
            {
                var data = dictionary.Load(settings.DictionariesPath + "insulti");
                var msg = data[new Random().Next(0, data.Length)];
                await BotApi.SendTextMessage(message.Chat.Id, string.Format(msg, messageMatches.Groups["action"].Value));
            }
            catch (Exception)
            {
                await BotApi.SendTextMessage(message.Chat.Id, "...idiota.. devi aver scritto qualche cazzata..");
            }
        }
    }
}
