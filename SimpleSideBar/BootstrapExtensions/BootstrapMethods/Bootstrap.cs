using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using SimpleSideBar.BootstrapExtensions.Controls;

namespace SimpleSideBar.BootstrapExtensions.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public HtmlHelper<TModel> Html;

        public Bootstrap(HtmlHelper<TModel> _html)
        {
            this.Html = _html;
        }

        public SidebarMenuItem SidebarMenuItem(string text, string url, string areaName, string actionName, string controllerName, IDictionary<string, object> routeValues)
        {
            return new SidebarMenuItem(Html, text, url, areaName, actionName, controllerName, routeValues);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return null; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
