using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace HaoXingLinPC
{
    public class RouteConfig
    {
        public static void RouteRegister(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute("index", "index", "~/index.aspx");
            routes.MapPageRoute("list", "list", "~/SurveyList.aspx");
            routes.MapPageRoute("error", "error", "~/ErrorMsg.aspx");
        }
    }
}