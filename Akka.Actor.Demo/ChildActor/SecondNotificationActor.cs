using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Actor.Demo.ChildActor
{
    internal class SecondNotificationActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Console.WriteLine($"Sending message with SecondNotification: {message}");
        }

        protected override void PreStart() => Console.WriteLine("Second Notification Actor started");

        protected override void PostStop() => Console.WriteLine("Second Notification Actor stopped");
      

    }
}
