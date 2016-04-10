using System.Web.Optimization;
using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using BundleTransformer.Core.Transformers;

namespace SimpleSideBar
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            var nullBuilder = new NullBuilder();
            var styleTransformer = new StyleTransformer();
            var scriptTransformer = new ScriptTransformer();
            var nullOrderer = new NullOrderer();

            // Replace a default bundle resolver in order to the debugging HTTP-handler
            // can use transformations of the corresponding bundle
            BundleResolver.Current = new CustomBundleResolver();

            //Style Bundles
            var bootstrapStylesBundle = new Bundle("~/css/bootstrap");
            bootstrapStylesBundle.Include(
                "~/Content/bootstrap-theme.min.css",
                "~/Content/bootstrap.min.css");
            bootstrapStylesBundle.Builder = nullBuilder;
            bootstrapStylesBundle.Transforms.Add(styleTransformer);
            bootstrapStylesBundle.Orderer = nullOrderer;
            bundles.Add(bootstrapStylesBundle);

            var siteStylesBundle = new Bundle("~/css/site");
            siteStylesBundle.Include("~/Content/font-awesome.min.css",
                "~/Content/site.css",
                "~/Content/animate.min.css");
            siteStylesBundle.Builder = nullBuilder;
            siteStylesBundle.Transforms.Add(styleTransformer);
            siteStylesBundle.Orderer = nullOrderer;
            bundles.Add(siteStylesBundle);

            //Script Bunldes
            var skinBundle = new Bundle("~/bundles/skin");
            skinBundle.Include("~/Scripts/skins.js");
            skinBundle.Builder = nullBuilder;
            skinBundle.Transforms.Add(scriptTransformer);
            skinBundle.Orderer = nullOrderer;
            bundles.Add(skinBundle);

            var jQueryBundle = new Bundle("~/bundles/jquery");
            jQueryBundle.Include("~/Scripts/jquery-2.2.2.min.js");
            jQueryBundle.Builder = nullBuilder;
            jQueryBundle.Transforms.Add(scriptTransformer);
            jQueryBundle.Orderer = nullOrderer;
            bundles.Add(jQueryBundle);

            var bootstrapBundle = new Bundle("~/bundles/bootstrap");
            bootstrapBundle.Include(
                  "~/Content/js/slimscroll/jquery.slimscroll.min.js",
                  "~/Scripts/bootstrap.min.js");
            bootstrapBundle.Builder = nullBuilder;
            bootstrapBundle.Transforms.Add(scriptTransformer);
            bootstrapBundle.Orderer = nullOrderer;
            bundles.Add(bootstrapBundle);

            var beyondBundle = new Bundle("~/bundles/site");
            beyondBundle.Include(
                  "~/Scripts/site.js");
            beyondBundle.Builder = nullBuilder;
            beyondBundle.Transforms.Add(scriptTransformer);
            beyondBundle.Orderer = nullOrderer;
            bundles.Add(beyondBundle);
        }
    }
}