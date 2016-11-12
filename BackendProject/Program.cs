using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Notification notification = new Notification();
           
            notification.SendNotifAndroid();

            notification.SendNotifAndroid("Xamathon");

            notification.SendNotifAndroid("Test");

            notification.GetRegistrationDevice();

            Console.ReadLine();
        }
    }
}
