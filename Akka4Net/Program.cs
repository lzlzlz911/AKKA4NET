namespace Akka4Net{

    using System;

    using Akka.Actor;

    internal class Program{

        private static void Main(string[] args){
            ActorSystem actorsystem = ActorSystem.Create("MySystem");
            IActorRef actorref = actorsystem.ActorOf<GreetingActor>("greeter");
            actorref.Tell(new GreetingMessage());
            Console.Read();
        }

    }

}