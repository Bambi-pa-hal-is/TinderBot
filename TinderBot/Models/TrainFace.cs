using ArreMath.Maths;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainFace
    {
        public TrainFace()
        {

        }
        public TrainFace(Face face)
        {
            this.Top = (float)face.faceRectangle.top;
            this.Left = (float)face.faceRectangle.left;
            this.Width = (float)face.faceRectangle.width;
            this.Height = (float)face.faceRectangle.height;

            this.Smile = face.faceAttributes.smile + 0.0f;
            this.Gender = face.faceAttributes.gender.ToLower().Contains("female") ? 1.0f : 0.0f;
            this.Age = face.faceAttributes.age;
            this.Glasses = !face.faceAttributes.glasses.ToLower().Contains("noglasses") ? 1.0f : 0.0f;

            this.Bald = face.faceAttributes.hair.bald;
            this.Invisible = face.faceAttributes.hair.invisible ? 1.0f : 0.0f;
            this.HairColor = face.faceAttributes.hair.hairColor.Count()==0 ? "" : face.faceAttributes.hair.hairColor.FirstOrDefault().color;
            this.Confidence = face.faceAttributes.hair.hairColor.Count()==0 ? 0 : face.faceAttributes.hair.hairColor.FirstOrDefault().confidence;

            this.Pitch = face.faceAttributes.headPose.pitch;
            this.Yaw = face.faceAttributes.headPose.yaw;
            this.Roll = face.faceAttributes.headPose.roll;

            this.Moustache = face.faceAttributes.facialHair.moustache;
            this.Beard = face.faceAttributes.facialHair.beard;
            this.Sideburns = face.faceAttributes.facialHair.sideburns;

            this.EyeMakeup = face.faceAttributes.makeup.eyeMakeup ? 1.0f : 0.0f;
            this.LipMakeup = face.faceAttributes.makeup.lipMakeup ? 1.0f : 0.0f;

            this.Anger = face.faceAttributes.emotion.anger;
            this.Contempt = face.faceAttributes.emotion.contempt;
            this.Disgust = face.faceAttributes.emotion.disgust;
            this.Fear = face.faceAttributes.emotion.fear;
            this.Happiness = face.faceAttributes.emotion.happiness;
            this.Neutral = face.faceAttributes.emotion.neutral;
            this.Sadness = face.faceAttributes.emotion.sadness;
            this.Surprise = face.faceAttributes.emotion.surprise;

            this.ForeheadOccluded = face.faceAttributes.occlusion.foreheadOccluded ? 1.0f : 0.0f;
            this.MouthOccluded= face.faceAttributes.occlusion.mouthOccluded ? 1.0f : 0.0f;
            this.EyeOccluded = face.faceAttributes.occlusion.eyeOccluded ? 1.0f : 0.0f;

            //this.BlurLevel = face.faceAttributes.blur.blurLevel;
            this.Value = face.faceAttributes.blur.value;

            //this.ExposureLevel = face.faceAttributes.exposure.exposureLevel;
            this.ExposureValue = face.faceAttributes.exposure.value;

            this.PupilLeft = new Vector3(face.faceLandmarks.pupilLeft.x, face.faceLandmarks.pupilLeft.y,0);
            this.PupilRight = new Vector3(face.faceLandmarks.pupilRight.x, face.faceLandmarks.pupilRight.y, 0);
            this.NoseTip = new Vector3(face.faceLandmarks.noseTip.x, face.faceLandmarks.noseTip.y, 0);
            this.MouthLeft = new Vector3(face.faceLandmarks.mouthLeft.x, face.faceLandmarks.mouthLeft.y, 0);
            this.MouthRight = new Vector3(face.faceLandmarks.mouthRight.x, face.faceLandmarks.mouthRight.y, 0);
            this.EyebrowLeftOuter = new Vector3(face.faceLandmarks.eyebrowLeftOuter.x, face.faceLandmarks.eyebrowLeftOuter.y, 0);
            this.EyebrowLeftInner = new Vector3(face.faceLandmarks.eyebrowLeftInner.x, face.faceLandmarks.eyebrowLeftInner.y, 0);
            this.EyeLeftOuter = new Vector3(face.faceLandmarks.pupilLeft.x, face.faceLandmarks.eyeLeftOuter.y, 0);
            this.EyeLeftTop = new Vector3(face.faceLandmarks.eyeLeftTop.x, face.faceLandmarks.eyeLeftTop.y, 0);
            this.EyeLeftBottom = new Vector3(face.faceLandmarks.eyeLeftBottom.x, face.faceLandmarks.eyeLeftBottom.y, 0);
            this.EyeLeftInner = new Vector3(face.faceLandmarks.eyeLeftInner.x, face.faceLandmarks.eyeLeftInner.y, 0);
            this.EyebrowRightInner = new Vector3(face.faceLandmarks.eyebrowRightInner.x, face.faceLandmarks.eyebrowRightInner.y, 0);
            this.EyebrowRightOuter = new Vector3(face.faceLandmarks.eyebrowRightOuter.x, face.faceLandmarks.eyebrowRightOuter.y, 0);
            this.EyeRightInner = new Vector3(face.faceLandmarks.eyeRightInner.x, face.faceLandmarks.eyeRightInner.y, 0);
            this.EyeRightTop = new Vector3(face.faceLandmarks.eyeRightTop.x, face.faceLandmarks.eyeRightTop.y, 0);
            this.EyeRightBottom = new Vector3(face.faceLandmarks.eyeRightBottom.x, face.faceLandmarks.eyeRightBottom.y, 0);
            this.EyeRightOuter = new Vector3(face.faceLandmarks.eyeRightOuter.x, face.faceLandmarks.eyeRightOuter.y, 0);
            this.NoseRootLeft = new Vector3(face.faceLandmarks.noseRootLeft.x, face.faceLandmarks.noseRootLeft.y, 0);
            this.NoseRootRight = new Vector3(face.faceLandmarks.noseRootRight.x, face.faceLandmarks.noseRootRight.y, 0);
            this.NoseLeftAlarTop = new Vector3(face.faceLandmarks.noseLeftAlarTop.x, face.faceLandmarks.noseLeftAlarTop.y, 0);
            this.NoseRightAlarTop = new Vector3(face.faceLandmarks.noseRightAlarTop.x, face.faceLandmarks.noseRightAlarTop.y, 0);
            this.NoseLeftAlarOutTip = new Vector3(face.faceLandmarks.noseLeftAlarOutTip.x, face.faceLandmarks.noseLeftAlarOutTip.y, 0);
            this.NoseRightAlarOutTip = new Vector3(face.faceLandmarks.noseRightAlarOutTip.x, face.faceLandmarks.noseRightAlarOutTip.y, 0);
            this.UpperLipTop = new Vector3(face.faceLandmarks.upperLipTop.x, face.faceLandmarks.upperLipTop.y, 0);
            this.UpperLipBottom = new Vector3(face.faceLandmarks.upperLipBottom.x, face.faceLandmarks.upperLipBottom.y, 0);
            this.UnderLipTop = new Vector3(face.faceLandmarks.underLipTop.x, face.faceLandmarks.underLipTop.y, 0);
            this.UnderLipBottom = new Vector3(face.faceLandmarks.underLipBottom.x, face.faceLandmarks.underLipBottom.y, 0);
        }

        public void Normalize()
        {
            Vector3 center = new Vector3(this.Left + this.Width / 2, this.Top + this.Height / 2, 0);

            float size = 256;

            this.PupilLeft = this.PupilLeft.TranslateToCenter(center).SetScale(1f/this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll))));
            this.PupilRight = this.PupilRight.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.NoseTip = this.NoseTip.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.MouthLeft = this.MouthLeft.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.MouthRight = this.MouthRight.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyebrowLeftOuter = this.EyebrowLeftOuter.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyebrowLeftInner = this.EyebrowLeftInner.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeLeftOuter = this.EyeLeftOuter.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeLeftTop = this.EyeLeftTop.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeLeftBottom = this.EyeLeftBottom.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeLeftInner = this.EyeLeftInner.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyebrowRightInner = this.EyebrowRightInner.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyebrowRightOuter = this.EyebrowRightOuter.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeRightInner = this.EyeRightInner.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeRightTop = this.EyeRightTop.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeRightBottom = this.EyeRightBottom.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.EyeRightOuter = this.EyeRightOuter.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.NoseRootLeft = this.NoseRootLeft.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.NoseRootRight = this.NoseRootRight.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.NoseLeftAlarTop = this.NoseLeftAlarTop.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.NoseRightAlarTop = this.NoseRightAlarTop.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.NoseLeftAlarOutTip = this.NoseLeftAlarOutTip.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.NoseRightAlarOutTip = this.NoseRightAlarOutTip.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.UpperLipTop = this.UpperLipTop.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.UpperLipBottom = this.UpperLipBottom.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.UnderLipTop = this.UnderLipTop.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll)))); 
            this.UnderLipBottom = this.UnderLipBottom.TranslateToCenter(center).SetScale(1f / this.Width).SetScale(size).RotateX(this.Pitch).RotateY(this.Yaw).RotateZ((-1 * ((float)Math.Sqrt(this.Roll * this.Roll))));

            this.Top -= (int)center.Y;
            this.Left -= (int)center.X;
        }


        [LoadColumn(0), ColumnName("Label")]
        public bool RightSwipe { get; set; } = false;

        //FaceRectangle
        [LoadColumn(1), ColumnName("Top")]
        public float Top { get; set; }
        [LoadColumn(2), ColumnName("Left")]
        public float Left { get; set; }
        [LoadColumn(3), ColumnName("Width")]
        public float Width { get; set; }
        [LoadColumn(4), ColumnName("Height")]
        public float Height { get; set; }

        //FaceAttributes
        [LoadColumn(5), ColumnName("Smile")]
        public float Smile { get; set; }
        [LoadColumn(6), ColumnName("Gender")]
        public float Gender { get; set; }
        [LoadColumn(7), ColumnName("Age")]
        public float Age { get; set; }
        [LoadColumn(8), ColumnName("Glasses")]
        public float Glasses { get; set; }
        //public object[] Accessories { get; set; }                   //<--- check this

        //Hair
        [LoadColumn(9), ColumnName("Bald")]
        public float Bald { get; set; }
        [LoadColumn(10), ColumnName("Invisible")]
        public float Invisible { get; set; }
        [LoadColumn(11), ColumnName("HairColor")]
        public string HairColor { get; set; }
        [LoadColumn(12), ColumnName("Confidence")]
        public float Confidence { get; set; }

        //HeadPose
        [LoadColumn(13), ColumnName("Pitch")]
        public float Pitch { get; set; }
        [LoadColumn(14), ColumnName("Roll")]
        public float Roll { get; set; }
        [LoadColumn(15), ColumnName("Yaw")]
        public float Yaw { get; set; }

        //Facialhair
        [LoadColumn(16), ColumnName("Moustache")]
        public float Moustache { get; set; }
        [LoadColumn(17), ColumnName("Beard")]
        public float Beard { get; set; }
        [LoadColumn(18), ColumnName("Sideburns")]
        public float Sideburns { get; set; }

        //Makeup
        [LoadColumn(19), ColumnName("EyeMakeup")]
        public float EyeMakeup { get; set; }
        [LoadColumn(20), ColumnName("LipMakeup")]
        public float LipMakeup { get; set; }

        //Emotion
        [LoadColumn(21), ColumnName("Anger")]
        public float Anger { get; set; }
        [LoadColumn(22), ColumnName("Contempt")]
        public float Contempt { get; set; }
        [LoadColumn(23), ColumnName("Disgust")]
        public float Disgust { get; set; }
        [LoadColumn(24), ColumnName("Fear")]
        public float Fear { get; set; }
        [LoadColumn(25), ColumnName("Happiness")]
        public float Happiness { get; set; }
        [LoadColumn(26), ColumnName("Neutral")]
        public float Neutral { get; set; }
        [LoadColumn(27), ColumnName("Sadness")]
        public float Sadness { get; set; }
        [LoadColumn(28), ColumnName("Surprise")]
        public float Surprise { get; set; }

        //Occlusion
        [LoadColumn(29), ColumnName("ForeheadOccluded")]
        public float ForeheadOccluded { get; set; }
        [LoadColumn(30), ColumnName("EyeOccluded")]
        public float EyeOccluded { get; set; }
        [LoadColumn(31), ColumnName("MouthOccluded")]
        public float MouthOccluded { get; set; }

        //Blur
        //[ColumnName("BlurLevel")]
        //public string BlurLevel { get; set; }
        [LoadColumn(32), ColumnName("Value")]
        public float Value { get; set; }

        //Exposure
       // [ColumnName("ExposureLevel")]
       // public string ExposureLevel { get; set; }
        [LoadColumn(33), ColumnName("ExposureValue")]
        public float ExposureValue { get; set; }

        //FaceLandmarks
        protected Vector3 PupilLeft { get; set; }
        protected Vector3 PupilRight { get; set; }
        protected Vector3 NoseTip { get; set; }
        protected Vector3 MouthLeft { get; set; }
        protected Vector3 MouthRight { get; set; }
        protected Vector3 EyebrowLeftOuter { get; set; }
        protected Vector3 EyebrowLeftInner { get; set; }
        protected Vector3 EyeLeftOuter { get; set; }
        protected Vector3 EyeLeftTop { get; set; }
        protected Vector3 EyeLeftBottom { get; set; }
        protected Vector3 EyeLeftInner { get; set; }
        protected Vector3 EyebrowRightInner { get; set; }
        protected Vector3 EyebrowRightOuter { get; set; }
        protected Vector3 EyeRightInner { get; set; }
        protected Vector3 EyeRightTop { get; set; }
        protected Vector3 EyeRightBottom { get; set; }
        protected Vector3 EyeRightOuter { get; set; }
        protected Vector3 NoseRootLeft { get; set; }
        protected Vector3 NoseRootRight { get; set; }
        protected Vector3 NoseLeftAlarTop { get; set; }
        protected Vector3 NoseRightAlarTop { get; set; }
        protected Vector3 NoseLeftAlarOutTip { get; set; }
        protected Vector3 NoseRightAlarOutTip { get; set; }
        protected Vector3 UpperLipTop { get; set; }
        protected Vector3 UpperLipBottom { get; set; }
        protected Vector3 UnderLipTop { get; set; }
        protected Vector3 UnderLipBottom { get; set; }

        [LoadColumn(34), ColumnName("PupilLeftVectorArray")]
        [VectorType(2)]
        public float[] PupilLeftVectorArray { get { return PupilLeft.ToTrainArray(); } }

        [LoadColumn(35), ColumnName("PupilRightVectorArray")]
        [VectorType(2)]
        public float[] PupilRightVectorArray { get { return PupilRight.ToTrainArray(); } }

        [LoadColumn(36), ColumnName("NoseTipVectorArray")]
        [VectorType(2)]
        public float[] NoseTipVectorArray { get { return NoseTip.ToTrainArray(); } }

        [LoadColumn(37), ColumnName("MouthLeftVectorArray")]
        [VectorType(2)]
        public float[] MouthLeftVectorArray { get { return MouthLeft.ToTrainArray(); } }

        [LoadColumn(38), ColumnName("MouthRightVectorArray")]
        [VectorType(2)]
        public float[] MouthRightVectorArray { get { return MouthRight.ToTrainArray(); } }

        [LoadColumn(39), ColumnName("EyebrowLeftOuterVectorArray")]
        [VectorType(2)]
        public float[] EyebrowLeftOuterVectorArray { get { return EyebrowLeftOuter.ToTrainArray(); } }

        [LoadColumn(40), ColumnName("EyebrowLeftInnerVectorArray")]
        [VectorType(2)]
        public float[] EyebrowLeftInnerVectorArray { get { return EyebrowLeftInner.ToTrainArray(); } }

        [LoadColumn(41), ColumnName("EyeLeftOuterVectorArray")]
        [VectorType(2)]
        public float[] EyeLeftOuterVectorArray { get { return EyeLeftOuter.ToTrainArray(); } }

        [LoadColumn(42), ColumnName("EyeLeftTopVectorArray")]
        [VectorType(2)]
        public float[] EyeLeftTopVectorArray { get { return EyeLeftTop.ToTrainArray(); } }

        [LoadColumn(43), ColumnName("EyeLeftBottomVectorArray")]
        [VectorType(2)]
        public float[] EyeLeftBottomVectorArray { get { return EyeLeftBottom.ToTrainArray(); } }

        [LoadColumn(44), ColumnName("EyeLeftInnerVectorArray")]
        [VectorType(2)]
        public float[] EyeLeftInnerVectorArray { get { return EyeLeftInner.ToTrainArray(); } }

        [LoadColumn(45), ColumnName("EyebrowRightInnerVectorArray")]
        [VectorType(2)]
        public float[] EyebrowRightInnerVectorArray { get { return EyebrowRightInner.ToTrainArray(); } }

        [LoadColumn(46), ColumnName("EyebrowRightOuterVectorArray")]
        [VectorType(2)]
        public float[] EyebrowRightOuterVectorArray { get { return EyebrowRightOuter.ToTrainArray(); } }

        [LoadColumn(47), ColumnName("EyeRightInnerVectorArray")]
        [VectorType(2)]
        public float[] EyeRightInnerVectorArray { get { return EyeRightInner.ToTrainArray(); } }

        [LoadColumn(48), ColumnName("EyeRightTopVectorArray")]
        [VectorType(2)]
        public float[] EyeRightTopVectorArray { get { return EyeRightTop.ToTrainArray(); } }

        [LoadColumn(49), ColumnName("EyeRightBottomVectorArray")]
        [VectorType(2)]
        public float[] EyeRightBottomVectorArray { get { return EyeRightBottom.ToTrainArray(); } }

        [LoadColumn(50), ColumnName("EyeRightOuterVectorArray")]
        [VectorType(2)]
        public float[] EyeRightOuterVectorArray { get { return EyeRightOuter.ToTrainArray(); } }

        [LoadColumn(51), ColumnName("NoseRootLeftVectorArray")]
        [VectorType(2)]
        public float[] NoseRootLeftVectorArray { get { return NoseRootLeft.ToTrainArray(); } }

        [LoadColumn(52), ColumnName("NoseRootRightVectorArray")]
        [VectorType(2)]
        public float[] NoseRootRightVectorArray { get { return NoseRootRight.ToTrainArray(); } }

        [LoadColumn(53), ColumnName("NoseLeftAlarTopVectorArray")]
        [VectorType(2)]
        public float[] NoseLeftAlarTopVectorArray { get { return NoseLeftAlarTop.ToTrainArray(); } }

        [LoadColumn(54), ColumnName("NoseRightAlarTopVectorArray")]
        [VectorType(2)]
        public float[] NoseRightAlarTopVectorArray { get { return NoseRightAlarTop.ToTrainArray(); } }

        [LoadColumn(55), ColumnName("NoseLeftAlarOutTipVectorArray")]
        [VectorType(2)]
        public float[] NoseLeftAlarOutTipVectorArray { get { return NoseLeftAlarOutTip.ToTrainArray(); } }

        [LoadColumn(56), ColumnName("NoseRightAlarOutTipVectorArray")]
        [VectorType(2)]
        public float[] NoseRightAlarOutTipVectorArray { get { return NoseRightAlarOutTip.ToTrainArray(); } }

        [LoadColumn(57), ColumnName("UpperLipTopVectorArray")]
        [VectorType(2)]
        public float[] UpperLipTopVectorArray { get { return UpperLipTop.ToTrainArray(); } }

        [LoadColumn(58), ColumnName("UpperLipBottomVectorArray")]
        [VectorType(2)]
        public float[] UpperLipBottomVectorArray { get { return UpperLipBottom.ToTrainArray(); } }

        [LoadColumn(59), ColumnName("UnderLipTopVectorArray")]
        [VectorType(2)]
        public float[] UnderLipTopVectorArray { get { return UnderLipTop.ToTrainArray(); } }

        [LoadColumn(60), ColumnName("UnderLipBottomVectorArray")]
        [VectorType(2)]
        public float[] UnderLipBottomVectorArray { get { return UnderLipBottom.ToTrainArray(); } }
    }
}
