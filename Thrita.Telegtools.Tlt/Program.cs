using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Thrita.Telegtools.EntityFramework;
using System.Reflection;

namespace Thrita.Telegtools.Tlt
{
    class Program
    {
        const string DefaultChannelName = "Telegram";
        const int DefaultFromPostId = 2;
        const int DefaultToPostId = 10;
        const string DefaultSaveDirectory = @"c:\temp\telegram\";

        private static string _channelName;
        private static int _fromPostId;
        private static int _toPostId;
        private static string _saveDirectory;

        static void Main(string[] args)
        {
            WriteAppInfo();

            try
            {
                if (args == null || args.Length == 0)
                {
                    ReadInputs();
                }
                else if (args.Length != 4)
                {
                    Console.WriteLine("\n\nUnknown syntaxt");
                    ShowSyntax();
                    Environment.Exit(-1);
                }
                else
                {
                    ReadArguments(args);
                }

                //Note: Only a test to prove we have write access permission to _saveDirectory:
                File.Create(Path.Combine(_saveDirectory, "{destination}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError:\n\t{0}", ex.Message);
                Environment.Exit(-1);
            }

            var workMan =
                new WorkManager(
                    new WebChannelTools(),
                    new List<ITelegramPostSaver>
                    {
                            new DiskWriter(_saveDirectory),
                            new DiskAttachmentSaver(_saveDirectory)
                    },
                    new ConsoleTraceListener());

            workMan.Execute(_channelName, _fromPostId, _toPostId);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private static void ShowSyntax(bool showDescription = false)
        {
            string appName = typeof(Program).Assembly.GetName().Name;
            if (showDescription)
                Console.WriteLine("\nDownloads posts, photos, and videos from a telegram channel.");
            Console.WriteLine("\nSyntax:");
            Console.WriteLine("\t{0} channelName fromPostID toPostID savePath", appName);
            Console.WriteLine("\nExample:");
            Console.WriteLine("\t{0} {1} {2} {3} {4}", appName, DefaultChannelName, DefaultFromPostId, DefaultToPostId, DefaultSaveDirectory);
            Console.WriteLine("\nNote: 'savePath' (like: {0}) must exists and you must have write access permission to that.", DefaultSaveDirectory);
        }

        private static void ReadArguments(string[] args)
        {
            _channelName = args[0];

            if (!int.TryParse(args[1], out _fromPostId) || _fromPostId < 0)
                throw new ArgumentException("fromPostId");

            if (!int.TryParse(args[2], out _toPostId) || _toPostId < _fromPostId)
                throw new ArgumentException("fromPostId");

            _saveDirectory = args[3];
        }

        private static void ReadInputs()
        {
            Console.Write("Channel name (like '{0}'): ", DefaultChannelName);
            _channelName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(_channelName))
                _channelName = DefaultChannelName;

            do
                Console.Write("From post ID (like '{0}'): ", DefaultFromPostId);
            while (!int.TryParse(Console.ReadLine(), out _fromPostId) || _fromPostId <= 0);

            do
                Console.Write("To post ID (like '{0}'): ", DefaultToPostId);
            while (!int.TryParse(Console.ReadLine(), out _toPostId) || _toPostId < _fromPostId);

            Console.Write("Accessible directory to save posts and files (like '{0}'): ", DefaultSaveDirectory);
            _saveDirectory = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(_saveDirectory))
                _saveDirectory = DefaultSaveDirectory;
        }

        private static void WriteAppInfo()
        {
            var assembly = typeof(Program).Assembly;

            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                var descriptionAttribute = (AssemblyDescriptionAttribute)attributes[0];
                Console.WriteLine(descriptionAttribute.Description);
            }

            Console.WriteLine("Version: {0}", assembly.GetName().Version);
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
