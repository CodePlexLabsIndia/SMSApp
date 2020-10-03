using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace SMSApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include
                              ( "~/Scripts/ace-elements.js.min.js",
                               "~/Scripts/index.js",
                               "~/Scripts/jquery_002.js",
                               "~/Scripts/jquery_003.js",
                               "~/Scripts/prefixfree.min.js",       
                               "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/styles").Include
                             ("~/Styles/style.css",
                             "~/Styles/font-awesome.css",
                             "~/Styles/css.css",
                             "~/Styles/ace.css",
                             "~/Styles/ace-responsive.css",
                             "~/Styles/ace-skins.css",
                             "~/Styles/jquery-ui-1.css",
                             "~/Styles/jquery.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}