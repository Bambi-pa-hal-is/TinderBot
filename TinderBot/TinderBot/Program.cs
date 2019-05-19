using CameraApi;
using CommandApi;
using FaceDetectionApi;
using FaceDetectionApi.Helpers;
using FaceDetectionApi.JavascriptInject;
using FaceDetectionApi.MicrosoftAzure;
using Models;
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
            MongoDBApi.MongoDBClient.Current.CreateTableIfNotExists("Arre");
            MongoDBApi.MongoDBClient.Current.InsertTrainData(new Face() { faceId = Guid.NewGuid().ToString(),RightSwipe = true }, "Arre");
            List<Face> arr = new List<Face>()
            {
                new Face() { faceId = Guid.NewGuid().ToString(),RightSwipe = false },
                new Face() { faceId = Guid.NewGuid().ToString(),RightSwipe = false }
            };
            MongoDBApi.MongoDBClient.Current.InsertTrainData(arr, "Arre");
            List<Face> hej = MongoDBApi.MongoDBClient.Current.GetAllDataFromTable("Arre");


            Camera.Current.LoadCamera();
            System.Threading.Thread.Sleep(4000);
            TinderArduinoClient.Current.Open();
            FDA.Init();
            BaseCommand.InitCommands();

            while (true)
            {
                var input = Console.ReadLine();
                BaseCommand.ExecuteSuitableCommand(input);
            }
        }
    }
}
