using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day3
{
    class NotificationService
    {
        private readonly INotification _notification;
        public NotificationService(INotification notification)
        {
            _notification = notification;
        }
        public void Notify(string message)
        {
            _notification.send(message);
        }
    }
}