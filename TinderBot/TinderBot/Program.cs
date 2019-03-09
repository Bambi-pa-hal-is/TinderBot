using CameraApi;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinderBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Camera c = new Camera();
            c.LoadCamera();
            while(true)
            {
                var test = Console.ReadLine();
                if(test.ToLower()=="cam")
                {
                    var camImage = c.GetCameraImage();
                    camImage.Save("bild.png",ImageFormat.Png);
                    var kalle = "hjej";
                    kalle += "5";
                }
            }
        }
    }
}
