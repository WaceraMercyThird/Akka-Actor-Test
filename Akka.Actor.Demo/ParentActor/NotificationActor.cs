using Akka.Actor.Demo.ChildActor;
using Akka.Actor.Dsl;
using Akka.DI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Actor.Demo
{
    class NotificationActor : UntypedActor
    {
        private readonly IEmailNotification _emailNotification;

        private readonly IActorRef _childActor;

        private readonly IActorRef _secondChildActor;

        public NotificationActor(IEmailNotification emailNotification)
        {
            _emailNotification = emailNotification;
            _childActor = Context.ActorOf(Context.System.DI().Props<TestNotificationActor>());
            _secondChildActor = Context.ActorOf(Context.System.DI().Props<SecondNotificationActor>());
        }
        protected override void OnReceive(object message)
        {
            Console.WriteLine($"Message recieve: {message}");
            _emailNotification.Send(message?.ToString());
            _childActor.Tell(message);
            _secondChildActor.Tell(message);
        }

        protected override void PreStart() => Console.WriteLine("Actor started");

        protected override void PostStop() => Console.WriteLine("Actor stoped");

    }
}
