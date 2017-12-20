using System;
using System.Threading.Tasks;

namespace Thrita.Telegtools.Tlt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Gather Channel History");
            Console.WriteLine("2. Authorize this app");
            Console.WriteLine("\nSelect: ");
            var selected = Console.ReadKey();

            try
            {
                switch (selected.Key)
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

            Console.WriteLine("THE END!");
#if DEBUG
            Console.WriteLine("Press a key.");
            Console.ReadKey();
#endif
        }

        static void GatherChannelHistory()
        {
            string channelName = "K1 in USA - 2";
            var callTask = Task.Run(() => new ChannelTools().GatherChannelHistory(channelName));
            callTask.Wait();
        }

        static void Authorize()
        {
            var callTask = Task.Run(() => new AuthorizeTool().AuthorizeAsyncStep1());
            callTask.Wait();
            var hash = callTask.Result;

            Console.Write("Enter Telegram Login Code (sent to your telegram app): ");
            var code = Console.ReadLine();
            var callTask2 = Task.Run(() => new AuthorizeTool().AuthorizeAsyncStep2(hash, code));
            callTask.Wait();
            Console.Write("Authorized successfully!");
        }
    }
}
