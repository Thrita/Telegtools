using System;
using System.Threading.Tasks;

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
            const string defaultChannelName = "K1 in USA - 2";
            Console.Write($"Enter the channel name (default: {defaultChannelName}): ");
            var channelName = Console.ReadLine();
            channelName = string.IsNullOrEmpty(channelName) ? defaultChannelName : channelName;
            var callTask = Task.Run(() => new ChannelTools().GatherChannelHistory(channelName));
            callTask.Wait();
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

    }
}
