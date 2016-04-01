namespace Akka4Net.Client
{
    #region Using

    using System;

    using Akka.Actor;
    using Akka.Configuration;

    using Akka4NET.Common;

    #endregion

    internal class Program
    {
        private static void Main(string[] args)
        {
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
                port = 0
                hostname = localhost
                }
                }
                }
                "
            );

            using (var system = ActorSystem.Create("MyClient", config))
            {
                var greeting = system.ActorSelection("akka.tcp://MyServer@localhost:8081/user/Greeting");
                Console.WriteLine("Client Run......");
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input.Equals("sayHello"))

//                        greeting.Tell(new GreetingMessage());
                    {
                        var result = greeting.Ask(new GreetingMessage()).Result as GreetingResponseMessage;
                        Console.WriteLine(result.UserName);
                    }
                }
            }
        }
    }
}