using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Management;
using System.Threading;

namespace TinderArduinoApi
{
    public class TinderArduinoClient
    {
        public SerialPort Port { get; set; }

        public TinderArduinoClient()
        {

        }

        public void Open()
        {
            //Port = new SerialPort();
            ConnectToArduino();
        }

        public void Left()
        {
            Console.WriteLine("Swiping left...");
            Port.Write("LEFT");
            Thread.Sleep(1500);
            Console.WriteLine("Swiping done!");
            return;
        }

        public void Right()
        {
            Console.WriteLine("Swiping right...");
            Port.Write("RIGHT");
            Thread.Sleep(1500);
            Console.WriteLine("Swiping done!");
            return;
        }

        public void Center()
        {
            Console.WriteLine("Swiping center...");
            Port.Write("CENTER");
            Thread.Sleep(1500);
            Console.WriteLine("Swiping done!");
            return;
        }

        public void Close()
        {
            Port.Close();
            
        }

        private void ConnectToArduino()
        {
            var allPorts = SerialPort.GetPortNames();
            foreach(var port in allPorts)
            {
                Port = new SerialPort(port,9600);
                try
                {
                    Port.Open();
                    Port.Write("TINDERCONNECT");
                    //Console.WriteLine("Writing....");


                    for(var i = 0; i != 10; i++)
                    {
                        var connectionResponse = Port.ReadExisting();
                        if (connectionResponse.Contains("TINDERRESPONSE"))
                        {
                            Console.WriteLine("Connected!");
                            return;
                        }
                        else
                        {
                            //Console.WriteLine("Response = " + connectionResponse);
                        }
                        Thread.Sleep(150);
                    }
                   
                }
                catch(Exception e)
                {

                }
                Console.WriteLine(port + " did not respond.");


            }
        }
    }
}
