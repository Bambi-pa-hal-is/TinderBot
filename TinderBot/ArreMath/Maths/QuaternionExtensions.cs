using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArreMath.Maths
{
    public static class QuaternionExtensions
    {
        //https://stackoverflow.com/questions/3982418/how-to-represent-a-4x4-matrix-rotation
        public static Vector3 SetScale(this Vector3 vector, float scaleX, float scaleY)
        {
            Matrix4x4 m4 = Matrix4x4.Identity;
            m4.M11 *= scaleX;
            m4.M12 *= scaleX;
            m4.M13 *= scaleX;

            m4.M21 *= scaleY;
            m4.M22 *= scaleY;
            m4.M23 *= scaleY;


            return Vector3.Transform(vector, m4);
        }

        public static Vector3 SetScale(this Vector3 vector, Vector2 scale)
        {
            return SetScale(vector, scale.X, scale.Y);
        }
        public static Vector3 SetScale(this Vector3 vector, float scale)
        {
            return SetScale(vector, scale, scale);
        }
    }
}
