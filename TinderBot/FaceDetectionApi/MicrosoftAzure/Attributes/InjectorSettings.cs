using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetectionApi.MicrosoftAzure.Attributes
{
    public class InjectorSettings : Attribute
    {
        public string Name { get; set; }
        public bool RunAtStart { get; set; }
        public string Url { get; set; }

        public InjectorSettings(string name, bool runAtStart = false, string url = null)
        {
            RunAtStart = runAtStart;
            Name = name;
            Url = url;
        }


    }

}

