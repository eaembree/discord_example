using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Webhook;
using Discord.WebSocket;

namespace DiscordExample.Modules
{
    public class WebHookModule : ModuleBase<SocketCommandContext>
    {
        const string executeWebhookFormat = "https://discordapp.com/api/webhooks/{0}/{1}";

        [Command("hook-test")]
        [Summary("Tests a webhook")]
        public async Task HookTestAsync()
        {
            ulong possibleChannelId = this.Context.Message.Channel.Id;
            //SocketChannel c = this.Context.Client.;
            //var st = new SocketTextChannel()
                //st.GetWebhooksAsync()

            var type = this.Context.Message.Channel.GetType();
            var typeString = type.ToString();

            if (this.Context.Message.Channel is SocketTextChannel stc)
            {
                var hooks = await stc.GetWebhooksAsync();
                Console.WriteLine(hooks.Count);

                var h = hooks.FirstOrDefault(x => string.Compare(x.Name, "Bot Hook", StringComparison.OrdinalIgnoreCase) == 0);
                if (h != null)
                {
                    // Id is the webhook id and token is the "user" token to authenticate
                    var url = string.Format(executeWebhookFormat, h.Id, h.Token);

                    var embed = new EmbedBuilder()
                    {
                        Title = "Diff Embed",
                        Description = "Diff Embed Test Description"
                    };

                    using (var client = new DiscordWebhookClient(url))
                    {
                        await client.SendMessageAsync("Diff Message from the bot!", embeds: new[] { embed.Build() });
                    }
                }
            }


            //using (var client = new DiscordWebhookClient(hookUrl))
            //{
            //    var embed1 = new EmbedBuilder()
            //    {
            //        Title = "Test Embed",
            //        Description = "Test Description"
            //    };

            //    var embed2 = new EmbedBuilder()
            //    {
            //        Title = "Another Test Embed",
            //        Description = "Another Test Description"
            //    };

            //    await client.SendMessageAsync("Message from the bot!", embeds: new[] { embed1.Build(), embed2.Build() });
            //}
        }
    }
}
