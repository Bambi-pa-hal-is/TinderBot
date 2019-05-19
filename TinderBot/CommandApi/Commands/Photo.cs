using System;
using System.Collections.Generic;
using System.Text;

namespace CommandApi.Commands
{
    public class Photo : BaseCommand
    {
        public Photo(string baseName) : base(baseName)
        {

        }

        public override object Execute<t>(string rawCommand)
        {
            var image = CameraApi.Camera.Current.GetCameraImage();
            return image;
        }
    }
}
