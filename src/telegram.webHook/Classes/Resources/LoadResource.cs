using Microsoft.Extensions.OptionsModel;
using System;
using System.IO;
using Telegram.Bot.Types;


namespace telegram.webHook.Classes.Resources
{
    public class LoadResource : IBotResources, IDisposable
    {
        private Stream stream { get; set; }
        
        public void Dispose()
        {
            stream.Dispose();
        }

        public FileToSend Load(string filename)
        {
    
            stream = new MemoryStream(System.IO.File.ReadAllBytes(filename));
            return new FileToSend(filename, stream);

        }
    }
}
