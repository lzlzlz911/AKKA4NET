namespace Akka4Net{
    #region Using

    using System;

    using Akka.Actor;

    #endregion

    public class GreetingActor : ReceiveActor{

        public GreetingActor() { Receive<GreetingMessage>(greet => Console.WriteLine("Receive")); }


    }

}