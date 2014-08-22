using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using EPiServer.ServiceLocation;
using EPiServer;


namespace BlocketProject.Helpers
{
    public static class NavigationHelpers
    {
        public static void RenderMainNavigation(this HtmlHelper html)
        {
            var writer = html.ViewContext.Writer;

            //Top level elements
            writer.WriteLine("<nav class=\"navbar navbar-inverse\">");
            writer.WriteLine("<ul class=\"nav navbar-nav\">");

            //Close top level elements
           

            writer.WriteLine("<li>");
            writer.WriteLine(html.PageLink(ContentReference.StartPage).ToHtmlString());
            writer.WriteLine("</li>");

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var topLevelPages = contentLoader.GetChildren<PageData>(ContentReference.StartPage);

            foreach (var topLvlPage in topLevelPages)
            {
                writer.WriteLine("<li>");
                writer.WriteLine(html.PageLink(topLvlPage).ToHtmlString());
                writer.WriteLine("</li>");
            }
            writer.WriteLine("</ul>");
            writer.WriteLine("</nav>");
        }
    }
}