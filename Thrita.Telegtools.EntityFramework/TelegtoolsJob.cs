using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thrita.Telegtools.EntityFramework
{
    [Table("Job")]
    public class TelegtoolsJob
    {
        [Key]
        public long Id { get; set; }

        public int FromPostId { get; set; }

        public int ToPostId { get; set; }

        [MaxLength(WebChannelTools.MAX_CHANNEL_NAME_LENGTH)]
        public string ChannelName { get; set; }

        public string Message { get; set; }


        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TelegtoolsJobStatus Status { get; set; }

        public TelegtoolsJob(string channelName = null, int fromPostId = 0, int toPostId=0)
        {
            StartDate = DateTime.UtcNow;
            if (channelName != null)
                this.ChannelName = channelName;
            this.FromPostId = fromPostId;
            this.ToPostId = toPostId;
            this.Logs = new List<TelegtoolsLog>();
        }

        public ICollection<TelegtoolsLog> Logs { get; set; }
    }

    public enum TelegtoolsJobStatus : byte
    {
        InProcess = 0,
        Done
    }
}
