namespace Akka4Net.Server
{
    #region Using

    using System;

    using Akka.Actor;

    using Akka4NET.Common;

    #endregion

    public class GreetingActorTwo : ReceiveActor
    {
        public GreetingActorTwo()
        {
            this.Receive<GreetingMessage>(greet => Console.WriteLine("ReceiveTwo"));
        }
    }
}