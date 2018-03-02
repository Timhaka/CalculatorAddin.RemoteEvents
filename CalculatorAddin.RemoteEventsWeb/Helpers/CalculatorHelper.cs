using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorAddin.RemoteEventsWeb.Helpers
{
    public class CalculatorHelper
    {
        public static Boolean ValidateCalculation(int itemId, ClientContext ctx)
        {

            List list = ctx.Web.GetListByTitle("Calculater");
            ListItem item = list.GetItemById(itemId);
            ctx.Load(item);
            ctx.ExecuteQuery();

            string calcOperator = item["calcOperator"].ToString();
            int calcNum1 = int.Parse(item["calcnum1"].ToString());
            int calcNum2 = int.Parse(item["calcnum2"].ToString());

            if (calcOperator == "devided" && calcNum2 == 0)
            {
                return false;
            }


            return true;
        }


        public static void DoCalculation(int itemId, ClientContext ctx)
        {

            List list = ctx.Web.GetListByTitle("Calculater");
            ListItem item = list.GetItemById(itemId);
            ctx.Load(item);
            ctx.ExecuteQuery();

            string calcOperator = item["calcOperator"].ToString();
            int calcNum1 = int.Parse(item["calcnum1"].ToString());
            int calcNum2 = int.Parse(item["calcnum2"].ToString());
            int? oldResult = null;

            if (item["calcResult"].ToString() == null)
            {
                oldResult = int.Parse(item["calcResult"].ToString());
            }

            int? newResult = null;

            switch (calcOperator)
            {
                case "plus":
                    newResult = calcNum1 + calcNum2;
                    break;
                case "minus":
                    newResult = calcNum1 - calcNum2;
                    break;
                case "devided":
                    double result = (calcNum1 / calcNum2);
                    newResult = (int)(Math.Round(result));
                    break;
                case "multipy":
                    newResult = calcNum1 * calcNum2;
                    break;
            }

            if (!oldResult.HasValue || oldResult.Value != newResult)
            {
                item["calcResult"] = newResult;
                   item.Update();
                ctx.ExecuteQuery();
            }



         


        }















    }
}