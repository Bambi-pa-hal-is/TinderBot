using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArreMath.Maths
{
    public static class QuaternionRotation
    {
        //https://stackoverflow.com/questions/3982418/how-to-represent-a-4x4-matrix-rotation
        
        public static Vector3 TranslateToCenter(this Vector3 v,Vector3 center)
        {
            v -= center;
            return v;
        }

        public static Vector3 TranslateBackToOriginal(this Vector3 v, Vector3 center)
        {
            v += center;
            return v;
        }

        public static Vector3 RotateZ(this Vector3 v, float angle) //Roll (Barrel roll med planet)
        {
            var radians = Math.PI * angle / 180.0;
            Matrix4x4 m4 = Matrix4x4.Identity;
            m4.M11 = (float)Math.Cos(-radians);
            m4.M12 = (float)Math.Sin(-radians);
            m4.M21 = -(float)Math.Sin(-radians);
            m4.M22 = (float)Math.Cos(-radians);
            return Vector3.Transform(v, m4);
        }


        public static Vector3 RotateY(this Vector3 v, float angle) //Yaw (Svänga med planet som en bil)
        {
            var radians = Math.PI * angle / 180.0;
            Matrix4x4 m4 = Matrix4x4.Identity;
            m4.M11 = (float)Math.Cos(-radians);
            m4.M13 = (float)Math.Sin(-radians);
            m4.M31 = -(float)Math.Sin(-radians);
            m4.M33 = (float)Math.Cos(radians);
            return Vector3.Transform(v, m4);
        }

        public static Vector3 RotateX(this Vector3 v, float angle) //Pitch (planet stiger/lyfter)
        {
            var radians = Math.PI * angle / 180.0;
            Matrix4x4 m4 = Matrix4x4.Identity;
            m4.M22 = (float)Math.Cos(-radians);
            m4.M23 = -(float)Math.Sin(-radians);
            m4.M32 = (float)Math.Sin(-radians);
            m4.M33 = (float)Math.Cos(-radians);
            return Vector3.Transform(v, m4);
        }


        public static Vector3 CalculateZDepthX(this Vector3 v,float yAngle,Vector3 center)
        {
            var radians = Math.PI * yAngle / 180.0;
            float deltaWidth = center.X - v.X;
            var dephth = Math.Tan(radians) * deltaWidth;
            v.Z = deltaWidth;
            return v;
        }
    }
}
