using System.Web;
using System.Web.Optimization;

namespace DressZone.Server
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                    "~/Scripts/themeScripts/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme/jquery").Include(
                    "~/Scripts/themeScripts/jquery-2.1.0.min.js"));

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

            //bundles.Add(new StyleBundle("~/Content/css")
            //        .Include("~/Content/css/*.css"));

        }
    }
}
