using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrita.Telegtools
{
    public interface IAttachmentTools
    {
        void Save(TelegramPost telegramPost);
        Task SaveAsync(TelegramPost telegramPost);
    }
}
