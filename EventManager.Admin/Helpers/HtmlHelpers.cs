using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EventManager.Admin.Helpers
{
    public static class HtmlHelpers
    {

        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static string TenantTypeDescription(string value)
        {
			//if (value.Equals("1"))
			//	return Resources.Resource.Enterprise;
			//else if (value.Equals("2"))
			//	return Resources.Resource.Ppersonal;
			//else
                return "";
        }

    }
}
