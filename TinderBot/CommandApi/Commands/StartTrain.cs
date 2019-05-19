using FaceDetectionApi;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TinderArduinoApi;

namespace CommandApi.Commands
{
    public class StartTrain : BaseCommand
    {
        public StartTrain(string baseName) : base(baseName)
        {

        }

        public override object Execute<t>(string rawCommand)
        {
            if(rawCommand.Split(' ').Length!=2)
            {
                Console.WriteLine("You need to add a name after StartTrain-command");
                return null;
            }
            string trainName = rawCommand.Split(' ')[1];
            Console.WriteLine("Trainmode activated! Press Escape to quit.");

            while(true)
            {
                bool swipeDirection = false;
                var pressedKey = Console.ReadKey();
                Console.WriteLine(pressedKey.KeyChar);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("Left");

                    swipeDirection = false;
                }
                if(pressedKey.Key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("Right");

                    swipeDirection = true;
                }
                System.IO.Directory.CreateDirectory("./" +trainName);
                if (pressedKey.Key == ConsoleKey.RightArrow || pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    var image = CameraApi.Camera.Current.GetCameraImage();
                    List<Face> faceData = FaceDetectionApi.FDA.CurrentMicrosoftAzureInjector.GetFaceImageData(image);
                    foreach(var item in faceData)
                    {
                        item.RightSwipe = swipeDirection;
                    }
                    string dataJson = JsonConvert.SerializeObject(faceData);
                    File.WriteAllText("./" + trainName + "/" + Guid.NewGuid().ToString() + ".json" , dataJson);
                    if(swipeDirection==true)
                    {
                        TinderArduinoClient.Current.Right();
                    }
                    else
                    {
                        TinderArduinoClient.Current.Left();
                    }
                }
                if(pressedKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
                System.Threading.Thread.Sleep(500);
            }
            
            return null;
        }
    }
}
