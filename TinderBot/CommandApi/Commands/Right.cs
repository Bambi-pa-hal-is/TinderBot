using System;
using System.Collections.Generic;
using System.Text;
using TinderArduinoApi;

namespace CommandApi.Commands
{
    public class Right : BaseCommand
    {
        public Right(string baseName) : base(baseName)
        {

        }

        public override object Execute<t>(string rawCommand)
        {
            TinderArduinoClient.Current.Right();
            return null;
        }
    }
}
