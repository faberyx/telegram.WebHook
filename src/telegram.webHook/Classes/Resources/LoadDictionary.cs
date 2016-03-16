using System;
using System.IO;
using Microsoft.Extensions.OptionsModel;

namespace telegram.webHook.Classes.Resources
{
    public class LoadDictionary : IBotDictionaries 
    {
        


        public string[] Load(string filename)
        {
            
            return File.ReadAllLines(filename + ".txt");
        }
    }
}
