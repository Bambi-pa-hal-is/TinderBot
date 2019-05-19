using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraApi
{
    public class Camera : IDisposable
    {
        public static Camera _current = null;
        public static Camera Current
        {
            get
            {
                if(_current==null)
                {
                    _current = new Camera();
                }
                return _current;
            }
            set
            {
                Current = value;
            }
        }

        public Thread CameraThread { get; set; }
        private CameraFrame CameraFrame { get; set; }
        public Camera()
        {

        }

        public void LoadCamera()
        {
            CameraFrame = new CameraFrame();
            CameraThread = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.Run(CameraFrame); // or whatever
            });
            CameraThread.Start();
        }

        public Bitmap GetCameraImage()
        {
            return this.CameraFrame.CaptureImage();
        }

        public void Dispose()
        {
            CameraThread.Abort();
        }
    }
}
