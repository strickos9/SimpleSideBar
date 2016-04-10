using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleSideBar.BootstrapExtensions.Controls
{
    public class SidebarMenuItem : IHtmlString
    {
        [EditorBrowsable(EditorBrowsableState.Never)]

        private readonly HtmlHelper _html;
        private bool _isDeropDown
        {
            get;
            set;
        }

        private string _icon
        {
            get;
            set;
        }

        private string _text
        {
            get;
            set;
        }

        private string _areaName
        {
            get;
            set;
        }

        private string _actionName
        {
            get;
            set;
        }

        private string _controllerName
        {
            get;
            set;
        }

        private string _url
        {
            get;
            set;
        }

        private RouteValueDictionary _routeValues
        {
            get;
            set;
        }

        public SidebarMenuItem(HtmlHelper html, string text, string url, string areaName, string actionName, string controllerName, IDictionary<string, object> routeValues)
        {
            _html = html;
            _actionName = actionName;
            _controllerName = controllerName;
            _text = text;
            _areaName = areaName;
            _routeValues = RemoveRoutes(routeValues);
            _url = url;
        }
        private static RouteValueDictionary RemoveRoutes(IDictionary<string, object> currentRouteData)
        {
            var routList = new RouteValueDictionary();
            var keyList = new List<string>(currentRouteData.Keys);

            var ignore = new[] { "Area", "Controller", "Action" };
            foreach (string key in keyList)
            {
                if (ignore.Contains(key, StringComparer.CurrentCultureIgnoreCase))
                    currentRouteData.Remove(key);
                else
                {
                    object value = null;
                    currentRouteData.TryGetValue(key, out value);
                    routList.Add(key, value);
                }
            }
            return routList;
        }

        public SidebarMenuItem IsDropDown()
        {
            _isDeropDown = true;
            return this;
        }

        public SidebarMenuItem Icon(string icon)
        {
            _icon = icon;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            var innerHtml = "";

            if (!string.IsNullOrEmpty(this._icon))
            {
                var i = new TagBuilder("i");
                i.AddCssClass("menu-icon " + this._icon.Replace("/", ""));
                innerHtml += i.ToString();
            }
            var span = new TagBuilder("span");
            span.AddCssClass("menu-text");
            span.InnerHtml = this._text;

            innerHtml += span.ToString();

            if (this._isDeropDown)
            {
                var expandi = new TagBuilder("i");
                expandi.AddCssClass("menu-expand");
                innerHtml += expandi.ToString();
            }

            var a = new TagBuilder("a");
            if (this._isDeropDown)
                a.AddCssClass("menu-dropdown");
            if (string.IsNullOrEmpty(this._url))
            {
                var urlHelper = new UrlHelper(_html.ViewContext.RequestContext);
                a.MergeAttribute("href", this._areaName + urlHelper.Action(this._actionName, this._controllerName, _routeValues));
            }
            else
            {
                a.MergeAttribute("href", this._url);
            }
            a.InnerHtml = innerHtml;

            return MvcHtmlString.Create(a.ToString()).ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return ToHtmlString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
