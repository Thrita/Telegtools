using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Thrita.Telegtools.EntityFramework
{
    [Table("Log")]
    public class TelegtoolsLog
    {
        [Key]
        public long Id { get; set; }

        public TraceLevel Level { get; set; }

        public int PostId { get; set; }

        [MaxLength(255)]
        public string ChannelName { get; set; }

        public string Message { get; set; }

        public DateTime LogDate { get; set; }

        [ForeignKey(nameof(TelegtoolsLog.Job))]
        public long? TelegtoolsJobId { get; set; }

        public TelegtoolsJob Job { get; set; }

        public TelegtoolsLog(string channelName = null, int postId = 0)
        {
            LogDate = DateTime.UtcNow;
            if (channelName != null)
                this.ChannelName = channelName;
            if (PostId > 0)
                this.PostId = postId;
        }
    }
}
