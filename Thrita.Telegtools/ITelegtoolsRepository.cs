using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrita.Telegtools
{
    public interface ITelegtoolsRepository
    {
        void Save(TelegramPost telegramPost);
        Task SaveAsync(TelegramPost telegramPost);
    }
}
