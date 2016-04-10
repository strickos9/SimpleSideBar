using System.Web.Mvc;
using SimpleSideBar.BootstrapExtensions.BootstrapMethods;

namespace SimpleSideBar.BootstrapExtensions
{
    public static class BootstrapHtmlExtension
    {
        public static Bootstrap<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> helper)
        {
            return new Bootstrap<TModel>(helper);
        }
    }
}
