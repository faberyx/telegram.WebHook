using Microsoft.AspNet.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using telegram.webHook.Classes.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace telegram.webHook.Classes.Bots
{
    public class FigaBot : IBotCommand
    {

        
        public BotSettings settings { get; set; }

        public Api BotApi { get; set; }

        public async Task Process(Message message, Match messageMatches)
        {
            try
            {
                string data;
                using (var client = new HttpClient())
                {
                    data = await client.GetStringAsync($"{settings.WebSiteFbot}?what={messageMatches.Groups["action"].Value.Trim()}");
                }
                var match = Regex.Match(data, "<img.*src=\"(.*)\".*class=\"random-image-img");
                string url = match.Groups[1].Value;
                Stream photodata = null;

                using (HttpClient client = new HttpClient())
                {
                    await client.GetStreamAsync(url).ContinueWith(
                        (req) => {
                            photodata =  req.Result;
                        }); 
                }
                
                var fl = new FileToSend($"figa_richiesta_da_{message.Chat.FirstName}.jpg", photodata);
                await BotApi.SendPhoto(message.Chat.Id, fl);
                photodata.Dispose();
            }
            catch (Exception)
            {
                await BotApi.SendTextMessage(message.Chat.Id, "...idiota.. devi aver scritto qualche cazzata..");
            }
        }
    }
}
