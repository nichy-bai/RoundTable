using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using Syn.Bot.Oscova.Entities;

namespace RoundTable.BotResources
{
    public class DefaultDialog : Dialog
    {
        [Expression("@start")]
        public void HelloIntent(Context context, Result result)
        {
            var response = new Response();
            response.Text = "Hello";
            result.SendResponse(response);
        }
    }
}