using Telegram.Bot;

namespace telegram.webHook.Classes
{
    public class Bot
    {
     
        public static Api GetApi(string token)
        {
            return new Api(token);
        }

   
    }
}