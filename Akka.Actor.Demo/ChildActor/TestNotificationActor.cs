using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Actor.Demo
{
    internal class TestNotificationActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Console.WriteLine($"Sending message with testNotification: {message}");
        }

        protected override void PreStart() => Console.WriteLine("Test Notification child started");

        protected override void PostStop() => Console.WriteLine("Test Notification child stopped");
        



    }
}
