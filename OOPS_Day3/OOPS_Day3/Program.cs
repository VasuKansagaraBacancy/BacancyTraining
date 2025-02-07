using OOPS_Day3;
using static OOPS_Day3.SmsNotification;

class Program
{
    static void Main()
    {
        INotification notification;
        Console.Write("Enter notification type (Email/SMS/Push): ");
        try
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "Email":
                    notification = new EmailNotification();
                    break;
                case "SMS":
                    notification = new SmsNotification();
                    break;
                case "Push":
                    notification = new PushNotification();
                    break;
                default:
                    Console.WriteLine("Invalid notification type");
                    return;
            }

            NotificationService service = new NotificationService(notification);
            service.Notify("Brother, this is your notification!");
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }           
    }
}
