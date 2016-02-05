namespace Akka4Net.Server{
    #region Using

    using System;

    using Akka.Actor;
    using Akka.Configuration;

    #endregion

    internal class Program{

        private static void Main(string[] args){
            var config = ConfigurationFactory.ParseString(
                @"
                akka {
                actor {
                provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                }
                remote {
                helios.tcp {
                transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
                applied-adapters = []
                transport-protocol = tcp
                port = 8081
                hostname = localhost
                }
                }
                }
                "
                );

            using (var system = ActorSystem.Create("MyServer", config))
            {
                system.ActorOf<GreetingActor>("Greeting");
                Console.ReadLine();
            }
        }

    }

}