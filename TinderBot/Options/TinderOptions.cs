using System;

namespace Options
{
    public class TinderOptions
    {
        private static TinderOptions _current = null;
        public static TinderOptions Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new TinderOptions();
                }
                return _current;
            }
            set
            {
                Current = value;
            }
        }



        public string Mode { get; set; }
        public string Table { get; set; } 

    }
}
