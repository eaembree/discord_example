using System.Threading.Tasks;

namespace DiscordExample.Services
{
    public class DatabaseAccessImpl : IDatabaseAccess
    {
        public Task<string> MessageByIdAsync(int id)
        {
            switch (id)
            {
                case 1: return Task.FromResult("Uno");
                case 2: return Task.FromResult("Dos");
                default: return Task.FromResult("I don't know this number");
            }
        }
    }
}