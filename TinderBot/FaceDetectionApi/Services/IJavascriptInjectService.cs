using FaceDetectionApi.Injectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetectionApi.JavascriptInject
{
    public interface IJavascriptInjectService
    {
        List<BaseInjector> Injectors { get; set; }
        void CreateInstances();
        void SetCurrentBrowser(WebBrowser browser);
        void WaitForBrowserToLoad();
        WebBrowser Browser { get; set; }
        void InjectJavascript(string scriptPath);

        void InjectRawJavascript(string script);
        void InitJavascriptInjection();
        void AddLibraries(string libraryPath);
        T InjectJavascript<T>(string scriptPath);
        T GetScraperOfType<T>(Type type);
        HtmlElementCollection GetElementsByTagName(string tagName);
    }
}
