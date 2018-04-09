using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    }
}
