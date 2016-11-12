using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;

namespace BackendProject
{
    public class Print
    {
        public static void AndroindRegistration(GcmRegistrationDescription item)
        {
            Console.WriteLine("GcmRegistrationId: {0}", item.GcmRegistrationId);
            Console.WriteLine("ETag: {0}", item.ETag);
            Console.WriteLine("RegistrationId: {0}", item.RegistrationId);
            Console.WriteLine("ExpirationTime: {0}", item.ExpirationTime);

            if (item.Tags != null)
            {
                Console.WriteLine("Tags: {0}", string.Join(" | ", item.Tags));
            }

            Console.WriteLine("----------");
        }
    }
}
