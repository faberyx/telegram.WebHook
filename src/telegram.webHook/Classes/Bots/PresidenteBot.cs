using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using telegram.webHook.Classes.Commands;
using telegram.webHook.Classes.Resources;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace telegram.webHook.Classes.Bots
{
    public class PresidenteaBot : IBotCommand
    {

        public BotSettings settings { get; set; }

        private LoadDictionary dictionary = new LoadDictionary();
        private LoadResource resource = new LoadResource();

        public Api BotApi { get; set; }

        public async Task Process(Message message, Match messageMatches)
        {
            try {
                switch (messageMatches.Groups["action"].Value.Trim())
                {

                    case "alien":
                        await BotApi.SendVideo(message.Chat.Id, resource.Load("aliens.mp4"));
                        resource.Dispose();
                        break;

                    case "uatistime":
                        await BotApi.SendVideo(message.Chat.Id, resource.Load("time.mp4"));
                        resource.Dispose();
                        await BotApi.SendTextMessage(message.Chat.Id, "...." + DateTime.Now.ToString("dd/MM/yyy HH:mm:ss"));
                        break;
                    case "talk":
                        if (string.IsNullOrEmpty(messageMatches.Groups["pattern"].Value))
                        {
                            var data = dictionary.Load(settings.DictionariesPath + "presidente");
                            var msg = data[new Random().Next(0, data.Length)];
                            await BotApi.SendTextMessage(message.Chat.Id, msg);
                        }
                        else
                        {
                            var pattern = messageMatches.Groups["pattern"].Value.Trim();
                            var data = dictionary.Load(settings.DictionariesPath +  "presidente_" + pattern.Replace("about ", ""));
                            var msg = data[new Random().Next(0, data.Length)];
                            await BotApi.SendTextMessage(message.Chat.Id, msg);
                            break;
                        }
                        break;

                }
            }catch(Exception){
                await BotApi.SendTextMessage(message.Chat.Id, "...idiota.. devi aver scritto qualche cazzata..");
            }
        }
    }
}