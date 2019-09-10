using ArreMath;
using ArreMath.Maths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointCloudRenderer
{
    public class GameWindow : Form
    {
        public Graphics G { get; set; }
        public Brush Brush { get; set; }
        public Bitmap Bitmap { get; set; }

        public List<Vector3> PointCloud { get; set; }
        public List<Rectangle> RectangleList { get; set; }

        public float xRot { get; set; }
        public float yRot { get; set; }
        public float zRot { get; set; }
        public float Time { get; set; }

        public Thread GameThread { get; set; }
        public GameWindow()
        {
            InitLayout();
            this.Width = 512;
            this.Height = 512;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "GameWindow";
            this.Location = new System.Drawing.Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            PointCloud = new List<Vector3>();
            RectangleList = new List<Rectangle>();
            var t = TemplateData.GetTemplateData();
            RectangleList.Add(new Rectangle((int)t.faceRectangle.top, (int)t.faceRectangle.left, (int)t.faceRectangle.width, (int)t.faceRectangle.height));

            xRot = 0;
            yRot = 0;
            zRot = 0;

            Brush = new SolidBrush(System.Drawing.Color.Azure);

            
            GameThread = new Thread(new ThreadStart(LaunchGameLoop));
            GameThread.Start();
        }

        public void InitGraphics()
        {
            while(this.IsHandleCreated==false)
            {
            }
            this.Invoke((MethodInvoker)delegate {
                G = this.CreateGraphics();
            });
        }

        public static GameWindow CreateGameWindow()
        {
            var window = new GameWindow();
            Thread GameThread = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.Run(window); // or whatever        
            });
            GameThread.Start();
            while(window.IsHandleCreated==false)
            {

            }
            return window;
        }

        private void LaunchGameLoop()
        {
            //Thread.Sleep(1000);
            this.InitGraphics();
            while(true)
            {
                UpdateGame();
                RenderGame();
                Thread.Sleep(33);
            }
        }

        public void UpdateGame()
        {
            //Console.WriteLine("Update");
        }

        public void RenderGame()
        {
            Brush = new SolidBrush(System.Drawing.Color.Black);
            G.FillRectangle(Brush, 0,0,1024, 1024);
            foreach(var v in PointCloud)
            {
                DrawCenteredAtXY(v, Color.Red);
            }

            var t = TemplateData.GetTemplateData();
            xRot = t.faceAttributes.headPose.pitch;
            yRot = t.faceAttributes.headPose.yaw;
            zRot = t.faceAttributes.headPose.roll;
            Time += 0.5f;
            foreach (var item in new List<Vector3>(PointCloud))
            {
                Vector3 center = new Vector3(t.faceRectangle.left + t.faceRectangle.width / 2, t.faceRectangle.top + t.faceRectangle.height / 2, 0);
                //Vector2 v = RotateVectorWithAngle(item, 90,center);
                //Vector3 v = RotateVectorWithAngle(item, -TemplateData.GetTemplateData().faceAttributes.headPose.roll, center);
                Vector3 v = item;
                Random r = new Random();
                v = v.TranslateToCenter(center);
                v = v.SetScale(1f/t.faceRectangle.width);
                v = v.SetScale(224f + (float)Math.Sin(Time)*3);

                Vector3 v2 = new Vector3(v.X,v.Y,v.Z);

                v = v.RotateX(xRot); // pitch   - Stiga lyfta med planet
                v = v.RotateY(yRot); // yaw     - Svänga med planet som en bil
                v = v.RotateZ(-1*((float)Math.Sqrt(zRot*zRot) + (Time*5))); // Roll    - Barrel roll med planet

                //v = v.TranslateToCenter(center);
                // v = v.RotateX(t.faceAttributes.headPose.pitch+);
                //v = v.CalculateZDepth(TemplateData.GetTemplateData().faceAttributes.headPose.pitch, center);
                //v = v.RotateX(TemplateData.GetTemplateData().faceAttributes.headPose.pitch);
                v = v.TranslateBackToOriginal(new Vector3(256, 256, 0));
                v2 = v2.TranslateBackToOriginal(new Vector3(256, 256, 0));
                DrawCenteredAtXY(v, Color.Green);
                DrawCenteredAtXY(v2, Color.Blue);

            }
        }

        public void DrawCenteredAtXY(Vector3 v, Color c)
        {
            Brush = new SolidBrush(c);
            var rect = new Rectangle((int)v.X, (int)v.Y, 6, 6);
            rect.X -= 3;
            rect.Y -= 3;
            G.FillRectangle(Brush, rect);
        }
    }
}
