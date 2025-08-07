using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Question_3
{
    internal class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string? message)
        {
            Console.WriteLine($"SMS Message sent to {recipient}: {message}");
        }
    }
}
