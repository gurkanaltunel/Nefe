using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Nefe.Web.App_Start
{
    public class BundleConfig
    {
        public static void AddBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/Css/Bootstrap").Include("~/Content/css/bootstrap.css"));
            bundles.Add(new Bundle("~/Css/Font-Awesome").Include("~/Content/css/font-awesome.min.css"));
            bundles.Add(new Bundle("~/Css/Select2").Include("~/Content/css/select2.min.css"));
            bundles.Add(new Bundle("~/Css/OwlCarousel").Include("~/Content/css/owl.carousel.css"));
            bundles.Add(new Bundle("~/Css/NoUISlider").Include("~/Content/css/nouislider.min.css"));
            bundles.Add(new Bundle("~/Css/Awesome-Checkbox").Include("~/Content/css/awesome-bootstrap-checkbox.min.css"));
            bundles.Add(new Bundle("~/Css/MyStyle").Include("~/Content/css/MyStyle.css"));
            bundles.Add(new Bundle("~/Script/Jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new Bundle("~/Script/Bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new Bundle("~/Script/Select2").Include("~/Scripts/select2.min.js"));
            bundles.Add(new Bundle("~/Script/OwlCarousel").Include("~/Scripts/owl.carousel.min.js"));
            bundles.Add(new Bundle("~/Script/NoUISlider").Include("~/Scripts/nouislider.min.js"));
            bundles.Add(new Bundle("~/Script/MyScripts").Include("~/Scripts/Site.js"));
        }
    }
}