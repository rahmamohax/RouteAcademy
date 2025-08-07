using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Question_3
{
    internal interface INotificationService
    {
        void SendNotification(string recipient, string? message);
    }
}
