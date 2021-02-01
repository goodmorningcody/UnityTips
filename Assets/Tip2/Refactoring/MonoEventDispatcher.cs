using System.Collections;
using UnityEngine;

namespace ReferenceAndEventDemo
{
    public interface Event
    {
    }

    public interface MonoEventListener
    {
        GameObject gameObject { get; }
        void OnEventHandle(Event param);
    }

    public static class MonoEventDispatcher
    {
        public static void Emit(this MonoBehaviour monoBehaviour, Event param)
        {
            monoBehaviour.StartCoroutine(Invoke(monoBehaviour, param));
        }

        private static IEnumerator Invoke(MonoBehaviour monoBehaviour, Event param)
        {
            var eventListeners = monoBehaviour.GetComponentsInParent<MonoEventListener>();
            foreach( var eventListener in eventListeners )
            {
                eventListener.OnEventHandle(param);
            }
            yield return null;
        }
    }
}