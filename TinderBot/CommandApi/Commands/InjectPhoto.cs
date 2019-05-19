using FaceDetectionApi;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandApi.Commands
{
    public class InjectPhoto : BaseCommand
    {
        public InjectPhoto(string baseName) : base(baseName)
        {

        }

        public override object Execute<t>(string rawCommand)
        {
            var image = CameraApi.Camera.Current.GetCameraImage();
            List<Face> faceData = FaceDetectionApi.FDA.CurrentMicrosoftAzureInjector.GetFaceImageData(image);
            return image;
        }
    }
}
