using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorAddin.RemoteEventsWeb.Helpers
{
    public class AppEventHelper
    {
        public static void Install(ClientContext ctx)
        {


            //add remove event to our list
            List list = ctx.Web.GetListByTitle("Calculator");
            string url = GetWebServiceUrl();

            list.AddRemoteEventReceiver("added2", url, EventReceiverType.ItemAdded, EventReceiverSynchronization.Synchronous, true);
            list.AddRemoteEventReceiver("updated2", url, EventReceiverType.ItemUpdated, EventReceiverSynchronization.Synchronous, true);
            list.AddRemoteEventReceiver("updating2", url, EventReceiverType.ItemUpdating, EventReceiverSynchronization.Synchronous, true);


        }
        public static void UnInstall(ClientContext ctx)
        {
            List list = ctx.Web.GetListByTitle("Calculator");
            list.GetEventReceiverByName("added2").DeleteObject();
            list.GetEventReceiverByName("updated2").DeleteObject();
            ctx.ExecuteQuery();

        }

        private static string GetWebServiceUrl()
        {
            System.ServiceModel.OperationContext op = System.ServiceModel.OperationContext.Current;
            System.ServiceModel.Channels.Message msg = op.RequestContext.RequestMessage;
            Uri url = msg.Headers.To;
            return url.ToString();
        }

    }
}