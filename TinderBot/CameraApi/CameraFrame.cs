using OpenCvSharp;
using OpenCvSharp.Extensions;
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
   

    public class CameraFrame : Form
    {
        public VideoCapture capture;
        public Mat frame;
        private Bitmap image;
        private Thread CaptureCameraThread;
        bool isCameraRunning = true;
        private bool setSizeOfFrame { get; set; } = true;
        public PictureBox CameraContainer { get; set; }
        private object _locker { get; set; } = new object();

        public CameraFrame()
        {
            InitLayout();
            CameraContainer = new PictureBox();
            this.Controls.Add(CameraContainer);
            this.Width = 5;
            this.Height = 5;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
           // this.ControlBox = false;
            this.Location = new System.Drawing.Point(0,0);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.FormBorderStyle = FormBorderStyle.None;
            CameraContainer.Dock = DockStyle.Fill;
            //CameraContainer.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            CaptureCameraThread = new Thread(new ThreadStart(CaptureCameraCallback));
            CaptureCameraThread.Start();
        }

        public Bitmap CaptureImage()
        {
            lock(_locker)
            {
                Bitmap image = null;
                CameraContainer.Invoke((MethodInvoker)delegate
                {
                    image = new Bitmap(CameraContainer.Image);
                });
                return image;
            }
        }

        private void CaptureCameraCallback()
        {
            Console.WriteLine("Capturing Camera...");
            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);
            //capture.Gain = 0;
            capture.AutoFocus = false;
            capture.Focus = 35;

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {
                    capture.Read(frame);
                    capture.Contrast = 128;
                    image = BitmapConverter.ToBitmap(frame);
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    if(setSizeOfFrame)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            this.Height = image.Height;
                            this.Width = image.Width;
                            //form.Label.Text = newText;
                        });
                        setSizeOfFrame = false;
                    }
                    
                    this.Width = image.Width;
                    this.Height = image.Height;
                    if (CameraContainer.Image != null)
                    {
                        CameraContainer.Image.Dispose();
                    }
                    lock(_locker)
                    {
                        CameraContainer.Image = image;
                    }
                }
            }
        }

        
    }
}
