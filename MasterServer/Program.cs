using System;
using System.Runtime.Remoting;

namespace MasterServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("MasterServer.exe.config", true);

            Console.WriteLine("MasterServer ready ");
            Console.ReadLine();
        }
    }
}
