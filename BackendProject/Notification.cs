using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;

namespace BackendProject
{
    public class Notification
    {
        private NotificationHubClient hub;

        public Notification()
        {
            hub =
                NotificationHubClient.CreateClientFromConnectionString(
                    "Endpoint=sb://xamathondemo.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=WriteKey",
                    "Xamathon");
        }

        public async void SendNotifApple()
        {
            NotificationOutcome outcome = null;

            string testMsg = "{\"aps\":{\"message\":\"Notification Hub test notification\", \"title\":\"Test ASPNET\"}}";
            try
            {
                outcome = await hub.SendAppleNativeNotificationAsync(testMsg);
                if (outcome != null)
                {
                    if (!((outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned) ||
                        (outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown)))
                    {
                        Console.WriteLine("Mesedge send!");
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

        }

        public async void SendNotifAndroid()
        {
            string testMsg = "{\"data\":{\"message\":\"Notification Hub test notification\", \"title\":\"BackendProject\"}}";
            NotificationOutcome outcome = await hub.SendGcmNativeNotificationAsync(testMsg);
            if (outcome != null)
            {
                if (!((outcome.State == NotificationOutcomeState.Abandoned) ||
                    (outcome.State == NotificationOutcomeState.Unknown)))
                {
                    Console.WriteLine("Mesedge send!");
                }
            }
        }

        public async void SendNotifAndroid(string tag)
        {
            string testMsg = "{\"data\":{\"message\":\"Notification Hub test notification for Tag\", \"title\":\"BackendProject\"}}";
            NotificationOutcome outcome = await hub.SendGcmNativeNotificationAsync(testMsg, tag);
            if (outcome != null)
            {
                if (!((outcome.State == NotificationOutcomeState.Abandoned) ||
                    (outcome.State == NotificationOutcomeState.Unknown)))
                {
                    Console.WriteLine("Mesedge send!");
                }
            }
        }

        public async void GetRegistrationDevice()
        {
            var result = await hub.GetAllRegistrationsAsync(100);

            foreach (RegistrationDescription item in result)
            {
                if (item is AppleRegistrationDescription)
                {
                    var appleItem = (AppleRegistrationDescription)item;
                    var tags = appleItem.Tags;
                    if (tags != null)
                    {
                        tags.ToString();
                    }
                }

                if (item is GcmRegistrationDescription)
                {
                    var androidItem = (GcmRegistrationDescription)item;

                    Print.AndroindRegistration(androidItem);

                }
            }

        }

    }
}
