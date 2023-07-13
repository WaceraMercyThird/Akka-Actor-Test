using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Actor.Demo
{
    public interface IEmailNotification
    {
        void Send (string message);
    }
}
