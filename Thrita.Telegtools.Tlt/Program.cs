using System;
using System.Threading.Tasks;
using System.Linq;

namespace Thrita.Telegtools.Tlt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                ShowMenu();
            }
            else
            {

            }
        }

        static void GatherChannelHistory()
        {
            //const string defaultChannelName = "K1 in USA - 2";
            //Console.Write($"Enter the channel name (default: {defaultChannelName}): ");
            //var channelName = Console.ReadLine();
            //channelName = string.IsNullOrEmpty(channelName) ? defaultChannelName : channelName;
            //var callTask = Task.Run(() => new ChannelTools().GatherChannelHistory(channelName));
            //callTask.Wait();

            var channelName = "K1inUSA";

            for (int i = 1; i <= 10; i++)
            {
                var callTask = Task.Run(() => GatherChannelHistoryFromWeb(channelName, i));
                callTask.Wait();
            }
        }

        static void Authorize()
        {
            var callTask = Task.Run(() => new AuthorizeTool().AuthorizeAsyncStep1());
            callTask.Wait();
            Console.Write("Enter Telegram Login Code (sent to your telegram app): ");
            var code = Console.ReadLine();
            var callTask2 = Task.Run(() => new AuthorizeTool().AuthorizeAsyncStep2(code));
            callTask.Wait();
            Console.Write("Authorized successfully!");
        }

        static void ShowMenu()
        {
            ConsoleKeyInfo selectedKey;

            do
            {
                Console.WriteLine("1. Gather Channel History");
                Console.WriteLine("2. Authorize this app");
                Console.WriteLine("X. Exit");
                Console.Write("\nSelect: ");
                selectedKey = Console.ReadKey();
                Console.WriteLine("\n");

                try
                {
                    switch (selectedKey.Key)
                    {
                        case ConsoleKey.D1:
                            GatherChannelHistory();
                            break;
                        case ConsoleKey.D2:
                            Authorize();
                            break;
                        case ConsoleKey.Enter:

                            //Task.Run(() => new ChannelTools().GatherChannelHistory_("K1 in USA - 2")).Wait();

                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)  //Exceptions here or in the function will be caught here
                {
                    int exLevel = 0;
                    while (ex != null)
                    {
                        Console.WriteLine(new string('\t', exLevel) + ex.Message);
                        ex = ex.InnerException;
                    }
                }
            } while (selectedKey.Key != ConsoleKey.X && selectedKey.Key != ConsoleKey.Escape);

            Console.WriteLine("THE END!");
#if DEBUG
            Console.WriteLine("Press a key.");
            Console.ReadKey();
#endif
        }


        public static void GatherChannelHistoryFromWeb(string channelName, int postId)
        {
            var url = string.Format("https://t.me/{0}/{1}?embed=1", channelName, postId);
            var web = new HtmlAgilityPack.HtmlWeb();
            var doc = web.Load(url);

            var div = doc.DocumentNode.Descendants("div")
                .SingleOrDefault(m => m.Attributes["class"]?.Value == "tgme_widget_message_text");


            if (div != null)
                Console.WriteLine(div.InnerHtml);
            else
                Console.WriteLine("_________________");

        }
    }
}
