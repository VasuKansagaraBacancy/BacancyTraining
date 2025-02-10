using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day3
{
    interface INotification
    {
        void send(string message);
    }
    class EmailNotification : INotification
    {
        public void send(string message)
        {
            Console.WriteLine("Sending Email: " + message);
        }
    }
    class SmsNotification : INotification
    {
        public void send(string message)
        {
            Console.WriteLine("Sending SMS: " + message);
        }
    public class PushNotification : INotification  
        {
            public void send(string message)
            {
                Console.WriteLine("Sending Push Notification: " + message);
            }
        }
    }
}