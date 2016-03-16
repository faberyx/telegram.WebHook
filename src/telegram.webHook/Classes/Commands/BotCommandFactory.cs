

using telegram.webHook.Classes.Bots;
 

namespace telegram.webHook.Classes.Commands
{
    class BotCommandFactory
    {
        public virtual IBotCommand CreateCommand(string type) {

            IBotCommand command = null;

            switch (type) {
                case "/gello":
                    command = new GelloBot();
                    break;
                case "/marco":
                    command = new MarcoBot();
                    break;
                case "/zarba":
                    command = new ZarbaBot();
                    break;
                case "/caterpillar":
                    command = new CaterpillarBot();
                    break;
                case "/lollo":
                    command = new LolloBot();
                    break;
                case "/mandafiga":
                    command = new FigaBot();
                    break;
                case "/presidente":
                    command = new PresidenteaBot();
                    break;
                case "/insulta":
                    command = new InsultaBot();
                    break;
            }
            return command;

        }
    }
}
