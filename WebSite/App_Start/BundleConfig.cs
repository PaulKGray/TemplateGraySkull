using System.Web;
using System.Web.Optimization;
using dotless.Core;
using Template.App_Start;

namespace Template
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
           

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendor/modernizr-*"));


						var lessBundle = new Bundle("~/Content/css").Include(
							"~/Content/normalize.css",
							"~/Content/master.less");
            lessBundle.Transforms.Add(new CssTransformer());
            lessBundle.Transforms.Add(new CssMinify());
            bundles.Add(lessBundle);

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }


        /// <summary>
        /// .Less Tranformer.
        /// </summary>
        class CssTransformer : IBundleTransform
        {
          public void Process(BundleContext context, BundleResponse response)
          {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
          }
        }
    }
}