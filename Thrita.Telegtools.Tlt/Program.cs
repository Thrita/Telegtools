using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Thrita.Telegtools.EntityFramework;

namespace Thrita.Telegtools.Tlt
{
    class Program
    {
        const string DefaultChannelName = "Telegram";

        static void Main(string[] args)
        {

            string directory = @"C:\Temp\TLT";


            var workMan =
                new WorkManager(
                    new WebChannelTools(),
                    new List<ITelegramPostSaver>
                    {
                        new DiskWriter(directory),
                        new DiskAttachmentSaver(directory)
                    },
                    new ConsoleTraceListener());

            workMan.Execute("k1inusa", 5380, 5390);

            Console.ReadLine();

            return;




            if (args == null || args.Length == 0)
            {
                ShowMenu();
            }
            else
            {

            }
        }

        static void GatherChannelHistory(string channelName)
        {
            //const string defaultChannelName = "K1 in USA - 2";
            //Console.Write($"Enter the channel name (default: {defaultChannelName}): ");
            //var channelName = Console.ReadLine();
            //channelName = string.IsNullOrEmpty(channelName) ? defaultChannelName : channelName;
            //var callTask = Task.Run(() => new ChannelTools().GatherChannelHistory(channelName));
            //callTask.Wait();

            channelName = channelName ?? DefaultChannelName;
            var tools = new WebChannelTools();

            for (int postId = 8; postId <= 11; postId++)
            {
                var telegramPost = tools.GetPost(channelName, postId);

                if (telegramPost == null)
                {
                    Console.WriteLine("Could not read post {0}.", postId);
                }
                else
                {
                    Console.Write("Saving post {0}. ", postId);
                    using (var ctx = new TelegtoolsContext("Thrita.Telegtools.EntityFramework.DbConnection"))
                    {
                        ctx.TelegramPosts.Add(telegramPost);
                        ctx.SaveChanges();
                        Console.WriteLine("Post {0} has saved.", postId);
                    }
                }
            }
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
                            GatherChannelHistory(null);
                            break;
                        case ConsoleKey.D2:
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

        public static TelegramPost GatherChannelHistoryFromWeb(string channelName, int postId)
        {
            IChannelTools tools = new WebChannelTools();
            return tools.GetPost(channelName, postId);
        }
    }
}
