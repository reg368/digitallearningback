using System.Web.Mvc;

namespace digitallearningback.App_Start
{
    public class ViewEngineConfig
    {
        public static void Register(ViewEngineCollection viewEngines)
        {
            //20170811-  調整ViewEngine 順序 先找.cshtml (RazorViewEngine) 後找 .aspx (WebFormViewEngine)
            //20170812 - 修正 , 不找 .aspx (WebFormViewEngine) 了 , 用不到
            viewEngines.Clear();
            viewEngines.Add(new CSharpRazorViewEngine());
        }

        //僅搜尋 cshtml (C# ) 檔 , vshtml (VB.NET) 檔 忽略
        internal class CSharpRazorViewEngine : RazorViewEngine
        {
            public CSharpRazorViewEngine()
            {
                AreaViewLocationFormats = new[] {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                };

                AreaMasterLocationFormats = new[] {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                };

                AreaPartialViewLocationFormats = new[] {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                };

                ViewLocationFormats = new[] {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml"
                };

                PartialViewLocationFormats = new[] {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml"
                };

                MasterLocationFormats = new[] {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml"
                };

                FileExtensions = new[] {
                    "cshtml"
                };
            }
        }

    }
}