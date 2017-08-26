using System.Web;
using System.Web.Optimization;

namespace digitallearningback
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/Gallery").Include(
                      "~/Content/Game/Gallery/gwdgesture_style.css",
                      "~/Content/Game/Gallery/gwdimage_style.css",
                      "~/Content/Game/Gallery/gwdpage_style.css",
                      "~/Content/Game/Gallery/gwdgallerynavigation_style.css",
                      "~/Content/Game/Gallery/gwdswipegallery_style.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/Gallery").Include(
                     "~/Scripts/Game/Gallery/googbase_min.js",
                     "~/Scripts/Game/Gallery/gwd_webcomponents_min.js",
                     "~/Scripts/Game/Gallery/gwdgesture_min.js",
                     "~/Scripts/Game/Gallery/gwdimage_min.js",
                     "~/Scripts/Game/Gallery/gwdpage_min.js",
                     "~/Scripts/Game/Gallery/gwdgallerynavigation_min.js",
                     "~/Scripts/Game/Gallery/gwdswipegallery_min.js",
                     "~/Scripts/Game/Gallery/gwd-events-support.1.0.js"
                     ));
        }
    }
}
