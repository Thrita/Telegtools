using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thrita.Telegtools.EntityFramework;

namespace Thrita.Telegtools.Tlt
{
    sealed class WorkManager
    {
        private readonly IChannelTools _channelTools;
        private readonly IEnumerable<ITelegramPostSaver> _postSavers;
        private readonly TraceListener _traceListener;

        public WorkManager(IChannelTools channelTools, IEnumerable<ITelegramPostSaver> postSavers, TraceListener traceListener)
        {
            _channelTools = channelTools;
            _postSavers = postSavers;
            _traceListener = traceListener;
        }

        public void Execute(string channelName, int fromPostId, int toPostId)
        {
            if (string.IsNullOrWhiteSpace(channelName))
                throw new ArgumentException(nameof(channelName));

            _traceListener.WriteLine($"Start getting '{channelName}' posts ({fromPostId} to {toPostId})...\n");

            try
            {
                for (int postId = fromPostId; postId <= toPostId; postId++)
                {
                    _traceListener.Write($"Start getting post #{postId}...");
                    var telegramPost = _channelTools.GetPost(channelName, postId);

                    if (telegramPost == null)
                    {
                        _traceListener.WriteLine($"\n\tCould not read post #{postId}.");
                    }
                    else
                    {
                        foreach (var postSaver in _postSavers)
                        {
                            try
                            {
                                postSaver.Save(telegramPost);
                                _traceListener.WriteLine($" Post #{postId} has been saved.");
                            }
                            catch (Exception ex)
                            {
                                _traceListener.WriteLine($"\n\tError in storing {postId} from '{channelName}'.");
                                _traceListener.WriteLine($"\t\tError:\n\t\t{ex}\n");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _traceListener.WriteLine($"\nError:");
                _traceListener.WriteLine($"\t{ex.Message}");
            }

            _traceListener.WriteLine($"\nFinished storing posts #{fromPostId} to #{toPostId} from channel '{channelName}'.\n");
        }
    }
}
