using System;
using System.IO;
using System.Web;
using System.Web.UI;
using RoundTable.BotResources;
using Syn.Bot.Channels.Testing;
using Syn.Bot.Channels.Widget;
using Syn.Bot.Oscova;

namespace RoundTable
{
    public partial class BotService : Page
    {
        private static WidgetChannel WidgetChannel { get; }
        private static OscovaBot Bot { get; }

        static BotService()
        {
            Bot = new OscovaBot();
            WidgetChannel = new WidgetChannel(Bot);

            String workspacePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BotResources\knowledge.json");
            Bot.ImportWorkspace(workspacePath);

            //Bot.Dialogs.Add(new ChannelTestDialog(Bot));
            Bot.Dialogs.Add(new DefaultDialog());

            Bot.Trainer.StartTraining();

            var websiteUrl =
                HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            WidgetChannel.ServiceUrl = websiteUrl + "/BotService.aspx";
            WidgetChannel.ResourceUrl = websiteUrl + "/BotResources";
            WidgetChannel.UseExternalResource = true;

            WidgetChannel.WidgetTitle = "RoundTable Chatbot";
            WidgetChannel.LaunchButtonText = "Chatbot";
            WidgetChannel.InputPlaceHolder = "Say Something...";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WidgetChannel.Process(Request, Response);
        }
    }
}