using FaceDetectionApi.Helpers;
using FaceDetectionApi.JavascriptInject;
using FaceDetectionApi.MicrosoftAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetectionApi
{
    public class FDA
    {

        public static JavascriptInjectService CurrentJSService { get; set; }
        public static MicrosoftAzureInjector CurrentMicrosoftAzureInjector { get; set; }

        public static void Init()
        {
            WebBrowserHelper.FixBrowserVersion();
            JavascriptInjectService CurrentJSService = new JavascriptInjectService();
            CurrentJSService.CreateInstances();

            CurrentMicrosoftAzureInjector = CurrentJSService.GetScraperOfType<MicrosoftAzureInjector>(typeof(MicrosoftAzureInjector));
        }
    }
}
