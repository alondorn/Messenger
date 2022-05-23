using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace AlonDorn.Messaging
{
    public class Messenger
    {
        static Dictionary<AppEvents, UnityEvent<string>> events = new Dictionary<AppEvents, UnityEvent<string>>();

        public static void Subscribe(AppEvents eventType, UnityAction<string> listener)
        {
            UnityEvent<string> currentEvent;

            if (events.TryGetValue(eventType, out currentEvent))
            {
                currentEvent.AddListener(listener);
            }
            else
            {
                currentEvent = new UnityEvent<string>();
                currentEvent.AddListener(listener);
                events.Add(eventType, currentEvent);
            }
        }

        public static void Unsubscribe(AppEvents eventType, UnityAction<string> listener)
        {
            UnityEvent<string> currentEvent;

            if (events.TryGetValue(eventType, out currentEvent))
            {
                currentEvent.RemoveListener(listener);
            }
        }

        public static void Execute(AppEvents eventType, string message = "")
        {
            UnityEvent<string> eventToExecute;
            if (events.TryGetValue(eventType, out eventToExecute))
            {
                eventToExecute.Invoke(message);
            }
        }

        /// <summary>
        /// Invoke after a certain amount of seconds.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="invokeTime"></param>
        /// <param name="message"></param>
        public static async void DelayedExecute(AppEvents eventType, float invokeTime, string message = "")
        {
            UnityEvent<string> eventToExecute;
            if (events.TryGetValue(eventType, out eventToExecute))
            {
                await Task.Delay(TimeSpan.FromSeconds(invokeTime));
                eventToExecute.Invoke(message);
            }
        }
    }
}

