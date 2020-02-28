using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordExample.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordExample.Modules
{
    public class DatabaseModule : ModuleBase<SocketCommandContext>
    {
        private readonly IServiceProvider _services;

        public DatabaseModule(IServiceProvider services)
        {
            _services = services;
        }

        [Command("read-message-by-id")]
        public async Task ReadMessageByIdAsync(int id)
        {
            string message;
            using (var scope = _services.CreateScope())
            {
                var database = scope.ServiceProvider.GetRequiredService<IDatabaseAccess>();
                message = await database.MessageByIdAsync(id);
            }

            await ReplyAsync(message);
        }
    }
}
