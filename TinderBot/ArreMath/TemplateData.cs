﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ArreMath
{
    public class TemplateData
    {

        public static string Template { get; set; } = "{'faceId':'dbfd6763-1cdd-43db-b7b7-0d1a41c8d593','faceRectangle':{'top':128,'left':459,'width':224,'height':224},'faceAttributes':{'hair':{'bald':0.1,'invisible':false,'hairColor':[{'color':'brown','confidence':0.99},{'color':'black','confidence':0.57},{'color':'red','confidence':0.36},{'color':'blond','confidence':0.34},{'color':'gray','confidence':0.15},{'color':'other','confidence':0.13}]},'smile':1,'headPose':{'pitch':-13.2,'roll':-11.9,'yaw':5},'gender':'female','age':24,'facialHair':{'moustache':0,'beard':0,'sideburns':0},'glasses':'ReadingGlasses','makeup':{'eyeMakeup':true,'lipMakeup':true},'emotion':{'anger':0,'contempt':0,'disgust':0,'fear':0,'happiness':1,'neutral':0,'sadness':0,'surprise':0},'occlusion':{'foreheadOccluded':false,'eyeOccluded':false,'mouthOccluded':false},'accessories':[{'type':'glasses','confidence':1}],'blur':{'blurLevel':'low','value':0},'exposure':{'exposureLevel':'goodExposure','value':0.48},'noise':{'noiseLevel':'low','value':0}},'faceLandmarks':{'pupilLeft':{'x':504.8,'y':206.8},'pupilRight':{'x':602.5,'y':178.4},'noseTip':{'x':593.5,'y':247.3},'mouthLeft':{'x':529.8,'y':300.5},'mouthRight':{'x':626,'y':277.3},'eyebrowLeftOuter':{'x':461,'y':186.8},'eyebrowLeftInner':{'x':541.9,'y':178.9},'eyeLeftOuter':{'x':490.9,'y':209},'eyeLeftTop':{'x':509.1,'y':199.5},'eyeLeftBottom':{'x':509.3,'y':213.9},'eyeLeftInner':{'x':529,'y':205},'eyebrowRightInner':{'x':579.2,'y':169.2},'eyebrowRightOuter':{'x':633,'y':136.4},'eyeRightInner':{'x':590.5,'y':184.5},'eyeRightTop':{'x':604.2,'y':171.5},'eyeRightBottom':{'x':608.4,'y':184},'eyeRightOuter':{'x':623.8,'y':173.7},'noseRootLeft':{'x':549.8,'y':200.3},'noseRootRight':{'x':580.7,'y':192.3},'noseLeftAlarTop':{'x':557.2,'y':234.6},'noseRightAlarTop':{'x':603.2,'y':225.1},'noseLeftAlarOutTip':{'x':545.4,'y':255.5},'noseRightAlarOutTip':{'x':615.9,'y':239.5},'upperLipTop':{'x':591.1,'y':278.4},'upperLipBottom':{'x':593.2,'y':288.7},'underLipTop':{'x':597.1,'y':308},'underLipBottom':{'x':600.3,'y':324.8}}}";
        public static string Template2 { get; set; } = "{ 'faceId': '2b660e21-9afa-49b0-9f51-7c3b968cae40', 'faceRectangle': { 'top': 127, 'left': 61, 'width': 204, 'height': 204 }, 'faceAttributes': { 'hair': { 'bald': 0.08, 'invisible': false, 'hairColor': [ { 'color': 'brown', 'confidence': 1.0 }, { 'color': 'black', 'confidence': 0.97 }, { 'color': 'gray', 'confidence': 0.15 }, { 'color': 'red', 'confidence': 0.09 }, { 'color': 'blond', 'confidence': 0.08 }, { 'color': 'other', 'confidence': 0.07 } ] }, 'smile': 0.0, 'headPose': { 'pitch': -6.3, 'roll': -1.6, 'yaw': 1.0 }, 'gender': 'female', 'age': 24.0, 'facialHair': { 'moustache': 0.0, 'beard': 0.0, 'sideburns': 0.0 }, 'glasses': 'NoGlasses', 'makeup': { 'eyeMakeup': true, 'lipMakeup': false }, 'emotion': { 'anger': 0.0, 'contempt': 0.0, 'disgust': 0.0, 'fear': 0.0, 'happiness': 0.0, 'neutral': 1.0, 'sadness': 0.0, 'surprise': 0.0 }, 'occlusion': { 'foreheadOccluded': false, 'eyeOccluded': false, 'mouthOccluded': false }, 'accessories': [], 'blur': { 'blurLevel': 'low', 'value': 0.14 }, 'exposure': { 'exposureLevel': 'goodExposure', 'value': 0.75 }, 'noise': { 'noiseLevel': 'low', 'value': 0.21 } }, 'faceLandmarks': { 'pupilLeft': { 'x': 119.4, 'y': 180.9 }, 'pupilRight': { 'x': 206.9, 'y': 180.0 }, 'noseTip': { 'x': 161.7, 'y': 237.5 }, 'mouthLeft': { 'x': 127.3, 'y': 280.1 }, 'mouthRight': { 'x': 201.2, 'y': 279.3 }, 'eyebrowLeftOuter': { 'x': 84.7, 'y': 163.5 }, 'eyebrowLeftInner': { 'x': 140.8, 'y': 162.2 }, 'eyeLeftOuter': { 'x': 102.3, 'y': 184.0 }, 'eyeLeftTop': { 'x': 119.3, 'y': 175.5 }, 'eyeLeftBottom': { 'x': 118.5, 'y': 190.0 }, 'eyeLeftInner': { 'x': 134.7, 'y': 184.8 }, 'eyebrowRightInner': { 'x': 183.0, 'y': 161.9 }, 'eyebrowRightOuter': { 'x': 242.8, 'y': 159.7 }, 'eyeRightInner': { 'x': 190.4, 'y': 184.4 }, 'eyeRightTop': { 'x': 206.2, 'y': 174.4 }, 'eyeRightBottom': { 'x': 206.9, 'y': 188.4 }, 'eyeRightOuter': { 'x': 221.3, 'y': 181.3 }, 'noseRootLeft': { 'x': 150.3, 'y': 189.5 }, 'noseRootRight': { 'x': 176.7, 'y': 189.0 }, 'noseLeftAlarTop': { 'x': 146.0, 'y': 222.1 }, 'noseRightAlarTop': { 'x': 179.8, 'y': 221.4 }, 'noseLeftAlarOutTip': { 'x': 137.2, 'y': 239.5 }, 'noseRightAlarOutTip': { 'x': 188.2, 'y': 239.6 }, 'upperLipTop': { 'x': 166.0, 'y': 271.4 }, 'upperLipBottom': { 'x': 165.9, 'y': 279.8 }, 'underLipTop': { 'x': 167.1, 'y': 283.5 }, 'underLipBottom': { 'x': 166.5, 'y': 298.5 } } }";

        public static string Template3 { get; set; } = "{ 'faceId': '5ebc4f72-e67f-4a9f-84f4-6e82922dbac3', 'faceRectangle': { 'top': 202, 'left': 550, 'width': 127, 'height': 127 }, 'faceAttributes': { 'hair': { 'bald': 0.0, 'invisible': true, 'hairColor': [] }, 'smile': 0.0, 'headPose': { 'pitch': 14.8, 'roll': 7.8, 'yaw': 32.0 }, 'gender': 'male', 'age': 41.0, 'facialHair': { 'moustache': 0.6, 'beard': 0.6, 'sideburns': 0.1 }, 'glasses': 'ReadingGlasses', 'makeup': { 'eyeMakeup': false, 'lipMakeup': false }, 'emotion': { 'anger': 0.0, 'contempt': 0.0, 'disgust': 0.0, 'fear': 0.0, 'happiness': 0.0, 'neutral': 0.844, 'sadness': 0.0, 'surprise': 0.155 }, 'occlusion': { 'foreheadOccluded': true, 'eyeOccluded': false, 'mouthOccluded': false }, 'accessories': [ { 'type': 'glasses', 'confidence': 1.0 }, { 'type': 'headwear', 'confidence': 1.0 } ], 'blur': { 'blurLevel': 'low', 'value': 0.0 }, 'exposure': { 'exposureLevel': 'goodExposure', 'value': 0.34 }, 'noise': { 'noiseLevel': 'medium', 'value': 0.43 } }, 'faceLandmarks': { 'pupilLeft': { 'x': 579.2, 'y': 242.6 }, 'pupilRight': { 'x': 626.3, 'y': 226.7 }, 'noseTip': { 'x': 617.0, 'y': 268.5 }, 'mouthLeft': { 'x': 606.3, 'y': 303.9 }, 'mouthRight': { 'x': 643.6, 'y': 289.6 }, 'eyebrowLeftOuter': { 'x': 556.3, 'y': 240.0 }, 'eyebrowLeftInner': { 'x': 595.2, 'y': 226.1 }, 'eyeLeftOuter': { 'x': 571.0, 'y': 246.6 }, 'eyeLeftTop': { 'x': 577.9, 'y': 239.8 }, 'eyeLeftBottom': { 'x': 579.1, 'y': 247.6 }, 'eyeLeftInner': { 'x': 587.0, 'y': 242.1 }, 'eyebrowRightInner': { 'x': 609.4, 'y': 222.4 }, 'eyebrowRightOuter': { 'x': 637.1, 'y': 203.2 }, 'eyeRightInner': { 'x': 620.0, 'y': 231.2 }, 'eyeRightTop': { 'x': 625.3, 'y': 223.6 }, 'eyeRightBottom': { 'x': 627.4, 'y': 230.2 }, 'eyeRightOuter': { 'x': 633.4, 'y': 224.0 }, 'noseRootLeft': { 'x': 598.7, 'y': 240.8 }, 'noseRootRight': { 'x': 612.6, 'y': 235.7 }, 'noseLeftAlarTop': { 'x': 602.3, 'y': 264.4 }, 'noseRightAlarTop': { 'x': 622.2, 'y': 253.6 }, 'noseLeftAlarOutTip': { 'x': 600.5, 'y': 277.5 }, 'noseRightAlarOutTip': { 'x': 629.4, 'y': 264.3 }, 'upperLipTop': { 'x': 624.7, 'y': 290.2 }, 'upperLipBottom': { 'x': 626.0, 'y': 294.3 }, 'underLipTop': { 'x': 628.2, 'y': 300.3 }, 'underLipBottom': { 'x': 630.2, 'y': 308.6 } } }";

        public static FaceData GetTemplateData()
        {
            FaceData f = new JavaScriptSerializer().Deserialize<FaceData>(Template2);
            return f;
        }

        public static List<Vector3> GetPointArray()
        {
            FaceData f = GetTemplateData();
            List<Vector3> pointCloud = new List<Vector3>();
            pointCloud.Add(new Vector3(f.faceLandmarks.eyebrowLeftInner.x, f.faceLandmarks.eyebrowLeftInner.y,0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyebrowLeftOuter.x, f.faceLandmarks.eyebrowLeftOuter.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyebrowRightInner.x, f.faceLandmarks.eyebrowRightInner.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyebrowRightOuter.x, f.faceLandmarks.eyebrowRightOuter.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeLeftBottom.x, f.faceLandmarks.eyeLeftBottom.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeLeftInner.x, f.faceLandmarks.eyeLeftInner.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeLeftOuter.x, f.faceLandmarks.eyeLeftOuter.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeLeftTop.x, f.faceLandmarks.eyeLeftTop.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeRightBottom.x, f.faceLandmarks.eyeRightBottom.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeRightInner.x, f.faceLandmarks.eyeRightInner.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeRightOuter.x, f.faceLandmarks.eyeRightOuter.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.eyeRightTop.x, f.faceLandmarks.eyeRightTop.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.mouthLeft.x, f.faceLandmarks.mouthLeft.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.mouthRight.x, f.faceLandmarks.mouthRight.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.noseLeftAlarOutTip.x, f.faceLandmarks.noseLeftAlarOutTip.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.noseLeftAlarTop.x, f.faceLandmarks.noseLeftAlarTop.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.noseRightAlarOutTip.x, f.faceLandmarks.noseRightAlarOutTip.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.noseRightAlarTop.x, f.faceLandmarks.noseRightAlarTop.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.noseRootLeft.x, f.faceLandmarks.noseRootLeft.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.noseRootRight.x, f.faceLandmarks.noseRootRight.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.noseTip.x, f.faceLandmarks.noseTip.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.pupilLeft.x, f.faceLandmarks.pupilLeft.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.pupilRight.x, f.faceLandmarks.pupilRight.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.underLipBottom.x, f.faceLandmarks.underLipBottom.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.underLipTop.x, f.faceLandmarks.underLipTop.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.upperLipBottom.x, f.faceLandmarks.upperLipBottom.y, 0));
            pointCloud.Add(new Vector3(f.faceLandmarks.upperLipTop.x, f.faceLandmarks.upperLipTop.y, 0));
          //  pointCloud.Add(new Vector3(f.faceRectangle.left, f.faceRectangle.top));
          //  pointCloud.Add(new Vector3(f.faceRectangle.left + f.faceRectangle.width, f.faceRectangle.top));
          //  pointCloud.Add(new Vector3(f.faceRectangle.left + f.faceRectangle.width, f.faceRectangle.top + f.faceRectangle.top));
          //  pointCloud.Add(new Vector3(f.faceRectangle.left, f.faceRectangle.top + f.faceRectangle.top));
            return pointCloud;
        }
    }
}
