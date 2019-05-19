using CommandApi.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CommandApi
{
    public abstract class BaseCommand
    {

        public static List<BaseCommand> AllCommands;
        public string baseName { get; set; }
        public static object LastCommandResponse = null;

        public BaseCommand(string baseName)
        {
            this.baseName = baseName;
        }

        public abstract object Execute<t>(string rawCommand);

        public static void InitCommands()
        {
            AllCommands = new List<BaseCommand>();
            AllCommands.Add(new Photo("photo"));
            AllCommands.Add(new Left("left"));
            AllCommands.Add(new Right("right"));
            AllCommands.Add(new InjectPhoto("injectphoto"));
            AllCommands.Add(new StartTrain("StartTrain"));

        }

        public static void ExecuteSuitableCommand(string rawInput)
        {
            rawInput = rawInput.ToLower();
            var firstWord = rawInput.Split(' ')[0];
            var command = AllCommands.Where(x => x.baseName.ToLower() == firstWord.ToLower()).FirstOrDefault();
            var response = command.Execute<object>(rawInput);
            if(response!=null)
            {
                Console.WriteLine("Command executed returned: " + response.GetType().Name);
                LastCommandResponse = response;
            }
        }
    }
}
