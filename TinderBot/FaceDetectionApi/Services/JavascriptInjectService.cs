using FaceDetectionApi.Injectors;
using FaceDetectionApi.MicrosoftAzure.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetectionApi.JavascriptInject
{
    public class JavascriptInjectService : IJavascriptInjectService
    {
        public List<BaseInjector> Injectors { get; set; }
        public WebBrowser Browser { get; set; }

        public void CreateInstances()
        {
            Injectors = new List<BaseInjector>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var allClasses = new List<Type>();

            foreach (var assembly in assemblies)
            {
                var classes = GetTypesWithScraperSettingsAttribute(assembly).ToList<Type>();
                allClasses.AddRange(classes);
            }

            foreach (var item in allClasses)
            {
                var classType = (BaseInjector)Activator.CreateInstance(item);
                Injectors.Add(classType);
                classType.JavascriptInjectService = this;
                //classType.Browser = new WebBrowser();
                

                InjectorSettings settings = classType.GetType().GetCustomAttribute<InjectorSettings>();
                classType.Name = settings.Name;
                if(!String.IsNullOrEmpty(settings.Url))
                {
                    classType.Url = settings.Url;
                }
                var t = new Thread(() => CreateBrowser(classType));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                while (classType.DoneLoading == false) { }
                //classType.BrowserForm.Hide();
                classType.Init();
            }
        }

        

        private void CreateBrowser(BaseInjector scraper)
        {
            scraper.Browser = new WebBrowser();
            scraper.Browser.Dock = DockStyle.Fill;
            scraper.Browser.Name = "webBrowser";
            scraper.Browser.ScrollBarsEnabled = true;
            scraper.Browser.TabIndex = 0;
            //scraper.Browser.Url = new Uri("http://www.microsoft.com");
            scraper.Browser.Navigate(scraper.Url);

            Form form = new Form();
           // form.WindowState = FormWindowState.Maximized;
            form.Controls.Add(scraper.Browser);
            form.Name = scraper.Name;
            //form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Height = 500;
            form.Width = 700;
            scraper.BrowserForm = form;

            scraper.DoneLoading = true;
            Application.Run(form);
            Thread.Sleep(1000);
        }

        public HtmlElementCollection GetElementsByTagName(string tagName)
        {
            HtmlElementCollection htmlElements = null;
            Browser.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                htmlElements = Browser.Document.GetElementsByTagName(tagName);
            });
            return htmlElements;
        }

        public void InjectJavascript(string scriptName)
        {
            //string javascript = "alert('Hello');";
            string defaultPath = "Scripts\\Custom\\";
            string projectPath = System.IO.Directory.GetCurrentDirectory();
            string combinedPath = Path.Combine(projectPath, defaultPath + scriptName);
            string script = File.ReadAllText(combinedPath);
            Browser.Invoke(new Action(() =>
            {
                Browser.Document.InvokeScript("eval", new object[] { script });
                Console.WriteLine("Injected: " + scriptName);
            }));
        }

        public void InjectRawJavascript(string script)
        {
            Browser.Invoke(new Action(() =>
            {
                Browser.Document.InvokeScript("eval", new object[] { script });
                Console.WriteLine("Injected Raw Javascript.");
            }));
        }

        public T InjectJavascript<T>(string script)
        {

            Browser.Invoke(new Action(() =>
            {
                var element = Browser.Document.GetElementById("ReturnToConsole");
                if (element == null)
                {
                  //  var tag = Browser.Document.CreateElement("div");
                  //  tag.Id = "ReturnToConsole";
                  //  Browser.Document.Body.AppendChild(tag);
                }
            }));

            Browser.Invoke(new Action(() =>
            {
                Browser.Document.InvokeScript("eval", new object[] { script });
            }));

            string json = "";
            while (String.IsNullOrEmpty(json))
            {
                Browser.Invoke(new Action(() =>
                {
                    var element = Browser.Document.GetElementById("ReturnToConsole");
                    if(element!=null)
                    {
                        json = Browser.Document.GetElementById("ReturnToConsole").InnerHtml;
                        //Browser.Document.GetElementById("ReturnToConsole").InnerHtml = "";
                        Browser.Document.GetElementById("ReturnToConsole").Id = Guid.NewGuid().ToString();
                    }
                }));
            }

            var data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }

        public void SetCurrentBrowser(WebBrowser browser)
        {
            Browser = browser;
        }

        public void WaitForBrowserToLoad()
        {
            bool returnBack = false;
            while (returnBack==false)
            {
                Browser.Invoke(new Action(() =>
                {
                    if(Browser.ReadyState==WebBrowserReadyState.Complete)
                    {
                        returnBack = true;
                    }
                }));
            }
            
        }



        private void BrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("Loaded");
        }

        private IEnumerable<Type> GetTypesWithScraperSettingsAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(InjectorSettings), true).Length > 0)
                {
                    InjectorSettings attrib = type.GetCustomAttribute<InjectorSettings>();
                    if(attrib.RunAtStart==true)
                    {
                        yield return type;
                    }
                }
            }
        }

        public void AddLibraries(string libraryName)
        {
           /* //string javascript = "alert('Hello');";
            string defaultPath = "Scripts\\Libraries\\";
            string projectPath = System.IO.Directory.GetCurrentDirectory();
            string combinedPath = Path.Combine(projectPath, defaultPath+libraryName);
            string libraryContent = File.ReadAllText(combinedPath);
            Browser.Invoke(new Action(() =>
            {
                Browser.Document.InvokeScript("eval", new object[] { libraryContent });
                Console.WriteLine("Invoked: " + libraryName);
            }));*/
        }

        public void InitJavascriptInjection()
        {

        }

        public T GetScraperOfType<T>(Type type)
        {
            var scraper = Injectors.Where(x => x.GetType() == type).FirstOrDefault();
            return (T)Convert.ChangeType(scraper,type);
        }
    }

}
