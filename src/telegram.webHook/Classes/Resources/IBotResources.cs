using System.IO;
using Telegram.Bot.Types;


namespace telegram.webHook.Classes.Resources

{
    interface IBotResources
    {
        FileToSend Load(string filename);
    }
}

