using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArreMath.Maths
{
    public static class Vector3Extensions
    {
        public static void CalculateFakePitchDepth(this Vector3 input, float pitch, List<Vector3> allPoints)
        {
            allPoints = allPoints.OrderBy(x => x.X).ToList();
            var allPointsY = new List<Vector3>(allPoints).OrderBy(x => x.Y).ToList();

            float minX = allPoints.FirstOrDefault().X;
            float maxX = allPoints.LastOrDefault().X;
            float width = maxX - minX;

            float minY = allPointsY.FirstOrDefault().Y;
            float maxY = allPointsY.LastOrDefault().Y;
            float height = maxY - minY;

            float centerDeltaX = (width * 0.5f) - input.X;
            float centerDeltaY = (height * 0.5f) - input.Y;

            //Math.Tan(pitch) * height
        }

        public static float[] ToTrainArray(this Vector3 v)
        {
            return new float[] { v.X, v.Y };
        }
    }

    
}
