namespace Akka4Net.Server
{
    #region Using

    using System;

    using Akka.Actor;

    using Akka4NET.Common;

    #endregion

    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            this.Receive<GreetingMessage>(
                                          greet =>
                                          {
                                              Console.WriteLine("Receive");
                                              this.Sender.Tell(
                                                               new GreetingResponseMessage()
                                                               {
                                                                   UserName = "lizhen"
                                                               });
                                          });

        }
    }
}