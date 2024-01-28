using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InterfacilityGatewayASPNET
{
    public class RouteConfig
    {
       public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
            name: "Details",
            //url: "{controller}/{action}/{id}/{LayoutUser}",
            //url: "{controller}/{action}/{id}/{LayoutUser}",
            url: "HandlerTransferRequest/detail/{id}/{LayoutUser}/{groupId}",
            new { controller = "HandlerTransferRequest", action = "Detail", id = UrlParameter.Optional, LayoutUser = UrlParameter.Optional, groupId = UrlParameter.Optional }
        );


            routes.MapRoute(
           name: "Indexs",
           //url: "{controller}/{action}/{id}/{groupId}",
           url: "HandlerTransferRequest/Index/{id}/{groupId}",
           new { controller = "HandlerTransferRequest", action = "Index", id = UrlParameter.Optional , groupId = UrlParameter.Optional }
           //new { controller = "HandlerTransferRequest", action = "Index", groupId = UrlParameter.Optional }
       );


            routes.MapRoute(
            name: "IsAdmitted",
            url: "HandlerTransferRequest/IsAdmitted/{id}/{groupId}",
            new { controller = "HandlerTransferRequest", action = "IsAdmitted", id = UrlParameter.Optional, groupId = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "IsOnTheWay",
            url: "HandlerTransferRequest/IsOnTheWay/{id}/{groupId}",
            new { controller = "HandlerTransferRequest", action = "IsOnTheWay", id = UrlParameter.Optional, groupId = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "FinalizeList",
            url: "HandlerTransferRequest/FinalizeList/{id}/{groupId}",
            new { controller = "HandlerTransferRequest", action = "FinalizeList", id = UrlParameter.Optional, groupId = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Create",
            url: "HandlerTransferRequest/Create/{id}",
            new { controller = "HandlerTransferRequest", action = "Create", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "PDFRetrival",
            url: "HandlerTransferRequest/PDFRetrival/{id}",
            new { controller = "HandlerTransferRequest", action = "PDFRetrival", id = UrlParameter.Optional }
        );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

          
        }
    }
}
