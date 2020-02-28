using System;
using System.Threading.Tasks;

namespace DiscordExample.Services
{
    public interface IDatabaseAccess
    {
        public Task<string> MessageByIdAsync(int id);
    }
}
