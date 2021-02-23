using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DavidPractice
{
    public interface EventListener
    {
        void OnEventHandle(Event param);
    }

    public static class EventDispatcher
    {
        public static void Emit(this MonoBehaviour monoBehaviour, Event param)
        {
            monoBehaviour.StartCoroutine(Invoke(monoBehaviour, param));
        }

        static IEnumerator Invoke(MonoBehaviour monoBehaviour, Event param)
        {
            var eventListeners = monoBehaviour.GetComponentsInParent<EventListener>();
            foreach (var eventListener in eventListeners)
            {
                eventListener.OnEventHandle(param);
            }
            yield return null;
        }
    }
}
