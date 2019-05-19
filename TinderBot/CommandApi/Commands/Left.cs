using System;
using System.Collections.Generic;
using System.Text;
using TinderArduinoApi;

namespace CommandApi.Commands
{
    public class Left : BaseCommand
    {
        public Left(string baseName) : base(baseName)
        {

        }

        public override object Execute<t>(string rawCommand)
        {
            TinderArduinoClient.Current.Left();
            return null;
        }
    }
}
