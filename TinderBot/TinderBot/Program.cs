using CameraApi;
using FaceDetectionApi.Helpers;
using FaceDetectionApi.JavascriptInject;
using FaceDetectionApi.MicrosoftAzure;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinderArduinoApi;

namespace TinderBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Camera c = new Camera();
            c.LoadCamera();
            System.Threading.Thread.Sleep(4000);
            //var image = c.GetCameraImage();

            WebBrowserHelper.FixBrowserVersion();
            JavascriptInjectService scraperService = new JavascriptInjectService();
            scraperService.CreateInstances();

            var jsInjector = scraperService.GetScraperOfType<MicrosoftAzureInjector>(typeof(MicrosoftAzureInjector));

            var arduinoClient = new TinderArduinoClient();
            arduinoClient.Open();

            //jsInjector.GetFaceImageData(image);

            while (true)
            {
                var test = Console.ReadLine();
                if(test.ToLower()=="cam")
                {
                    var camImage = c.GetCameraImage();
                    jsInjector.GetFaceImageData(camImage);
                    //camImage.Save("bild.png",ImageFormat.Png);
                    //var kalle = "hjej";
                    //kalle += "5";
                }

                if(test.ToLower() == "left")
                {
                    arduinoClient.Left();
                }
                if (test.ToLower() == "right")
                {
                    arduinoClient.Right();
                }
                if (test.ToLower() == "center")
                {
                    arduinoClient.Center();
                }
                if(test.ToLower() == "quit")
                {
                    arduinoClient.Close();
                    break;
                }
            }
        }
    }
}
