using FaceDetectionApi.JavascriptInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetectionApi.Injectors
{
    public abstract class BaseInjector
    {
        public IJavascriptInjectService JavascriptInjectService { get; set; }
        public WebBrowser Browser { get; set; }
        public Form BrowserForm { get; set; }
        public string JavaScriptToolbox { get; set; }
        public string JavaScriptInjector { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public bool DoneLoading = false;

        public abstract void Init();
    }
}
