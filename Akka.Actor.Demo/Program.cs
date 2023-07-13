using Akka.Actor.Demo.ChildActor;
using Akka.DI.Core;
using Akka.DI.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Actor.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IEmailNotification, EmailNotification>();

            serviceCollection.AddSingleton<NotificationActor>();

            serviceCollection.AddSingleton<TestNotificationActor>();

            serviceCollection.AddSingleton<SecondNotificationActor>();

            var ServiceProvider = serviceCollection.BuildServiceProvider();

            //set actor
            var actorSystem = ActorSystem.Create("test-actor-system");

            actorSystem.UseServiceProvider(ServiceProvider);

            var actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());

            //invoke actor
            actor.Tell("Hello There");

            Console.ReadLine();

            actorSystem.Stop(actor);

            Console.ReadLine();
        }
    }
}
