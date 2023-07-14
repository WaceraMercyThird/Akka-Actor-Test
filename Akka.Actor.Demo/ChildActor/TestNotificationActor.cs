using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Actor.Demo
{
    internal class TestNotificationActor : UntypedActor
    {

        protected override void PreStart() => Console.WriteLine("Test Notification child started");

        protected override void PostStop() => Console.WriteLine("Test Notification child stopped");

        protected override void OnReceive(object message)
        {
            if (message.ToString() == "n")
            {
                throw new NullReferenceException();
            }
            else if(message.ToString() == "e")
            {
                throw new ArgumentException();
            }
            else if (string.IsNullOrWhiteSpace(message.ToString()))
            {
                throw new Exception();
            }

            Console.WriteLine($"Sending message with testNotification: {message}");
            
        }

  



    }
}
