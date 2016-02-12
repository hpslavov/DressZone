using System.Web;
using System.Web.Optimization;

namespace DressZone.Server
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/private-functions").Include("~/Scripts/layout.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery11").Include("~/Scripts/themeScripts/jquery-1.11.0.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerymigrate").Include("~/Scripts/themeScripts/jquery-migrate-1.2.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/js/theme").Include(
                    "~/Scripts/themeScripts/jquery.jpanelmenu.js",
                    "~/Scripts/themeScripts/jquery.themepunch.plugins.min.js",
                    "~/Scripts/themeScripts/jquery.themepunch.revolution.min.min.js",
                    "~/Scripts/themeScripts/jquery.themepunch.showbizpro.min.js",
                    "~/Scripts/themeScripts/jquery.magnific-popup.min.js",
                    "~/Scripts/themeScripts/hoverIntent.js",
                    "~/Scripts/themeScripts/superfish.js",
                    "~/Scripts/themeScripts/jquery.pureparallax.js",
                    "~/Scripts/themeScripts/jquery.pricefilter.js",
                    "~/Scripts/themeScripts/jquery.selectric.min.js",
                    "~/Scripts/themeScripts/jquery.royalslider.min.js",
                    "~/Scripts/themeScripts/SelectBox.js",
                    "~/Scripts/themeScripts/modernizr.custom.js",
                    "~/Scripts/themeScripts/waypoints.min.js",
                    "~/Scripts/themeScripts/jquery.flexslider-min.js",
                    "~/Scripts/themeScripts/jquery.counterup.min.js",
                    "~/Scripts/themeScripts/jquery.tooltips.min.js",
                    "~/Scripts/themeScripts/jquery.appear.js",
                    "~/Scripts/themeScripts/jquery.isotope.min.js",
                    "~/Scripts/themeScripts/puregrid.js",
                    "~/Scripts/themeScripts/stacktable.js",
                    "~/Scripts/themeScripts/custom.js"
                    ));

            //bundles.Add(new ScriptBundle("~/bundles/theme/jquery").Include(
            //        "~/Scripts/themeScripts/jquery-2.1.0.min.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                    .Include(
                    "~/Content/base.css",
                    "~/Content/beige.css",
                    "~/Content/blue.css",
                    "~/Content/bootstrap.css",
                    "~/Content/brown.css",
                    "~/Content/celadon.css",
                    "~/Content/cherry.css",
                    "~/Content/cyan.css",
                    "~/Content/dark.css",
                    "~/Content/font-awesome.css",
                    "~/Content/gray.css",
                    "~/Content/green.css",
                    "~/Content/navy.css",
                    "~/Content/orange.css",
                    "~/Content/olive.css",
                    "~/Content/peach.css",
                    "~/Content/pink.css",
                    "~/Content/purple.css",
                    "~/Content/red.css",
                    "~/Content/responsive.css",
                    "~/Content/style.css",
                    "~/Content/switcher.css",
                    "~/Content/yellow.css"));
        }
    }
}
