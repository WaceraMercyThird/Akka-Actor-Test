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

            serviceCollection.AddScoped<IEmailNotification, EmailNotification>();

            serviceCollection.AddScoped<NotificationActor>();

            serviceCollection.AddScoped<TestNotificationActor>();

            serviceCollection.AddScoped<SecondNotificationActor>();

            var ServiceProvider = serviceCollection.BuildServiceProvider();

            //set actor
            var actorSystem = ActorSystem.Create("test-actor-system");

            actorSystem.UseServiceProvider(ServiceProvider);

            var actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());


            Console.WriteLine("Enter message");

            while (true)
            {
                var message = Console.ReadLine();
                if (message == "q") break;
                actor.Tell(message);
            }
            //invoke actor
            //actor.Tell("Hello There");

            //Console.ReadLine();

            actorSystem.Stop(actor);

            Console.ReadLine();
        }
    }
}
