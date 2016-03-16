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
                string what = "";

                switch (messageMatches.Groups["action"].Value.Trim())
                {
                    case "bionda":
                        what = "?what=blonde";
                        break;
                    case "bruna":
                        what = "?what=brunette";
                        break;
                    case "rossa":
                        what = "?what=redhead";
                        break;
                }

                using (var client = new HttpClient())
                {
                    data = await client.GetStringAsync($"http://www.sexyandfunny.com/10randomphotos.php{what}");
                }
                var match = Regex.Match(data, "<img.*src=\"(.*)\".*class=\"random-image-img");
                string url = match.Groups[1].Value;
                Stream photodata;

                using (HttpClient client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    {

                        photodata = await (await client.SendAsync(request)).Content.ReadAsStreamAsync();
                         
                    }

                }

                var fl = new FileToSend(string.Format("figa_richiesta_da_{0}.jpg", message.Chat.FirstName), photodata);
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
