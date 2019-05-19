using FaceDetectionApi.Injectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceDetectionApi.MicrosoftAzure.Attributes;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Models;

namespace FaceDetectionApi.MicrosoftAzure
{
    [InjectorSettings("MicrosoftAzureInjector", true, "https://azure.microsoft.com/sv-se/services/cognitive-services/face/")]
    public class MicrosoftAzureInjector : BaseInjector
    {
        public override void Init()
        {
            Console.WriteLine("Injecting... " + this.Name + "...");
            JavascriptInjectService.SetCurrentBrowser(Browser);
            JavascriptInjectService.WaitForBrowserToLoad();
            Console.WriteLine(this.Name + " has loaded!");


            JavascriptInjectService.AddLibraries("jQuery-3.3.1.js");
            JavascriptInjectService.AddLibraries("Toolbox.js");

            /*var operators = JavascriptInjectService.InjectJavascript<List<object>>("NetAtOnceScrape.js");
            foreach (var item in operators)
            {
                Console.WriteLine(item);
            }*/
            //Console.WriteLine(returnType.Name);
        }

        public List<Face> GetFaceImageData(Bitmap image)
        {
            //var htmlItems = JavascriptInjectService.GetElementsByTagName("input");
            System.IO.MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            var imageAsBase64 = "data:image/png;base64," + Convert.ToBase64String(byteImage); // Get Base64

            this.Browser.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                this.Browser.Document.GetElementById("FaceDetection_Image_Base64Url").SetAttribute("value", imageAsBase64);
            });


            string startupPath = System.IO.Directory.GetCurrentDirectory();

            string startupPath2 = Environment.CurrentDirectory;

            string javascript = File.ReadAllText( "./Scripts/InjectImage.js");




            List<Face> faceData = JavascriptInjectService.InjectJavascript<List<Face>>(javascript);

            //document.getElementById("FaceDetection_Image_Base64Url").value

            /*<input 
             * role="button" 
             * type="file" 
             * accept="" 
             * name="FaceDetection.Image.File" 
             * data-event="area-products-demo-clicked-upload" 
             * data-event-property="Face Detection">*/
            //this.JavascriptInjectService.Inj
            return faceData;
        }
    }
}
