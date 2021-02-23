using System;
using System.Collections.Generic;

namespace MVC
{
    //https://en.wikipedia.org/wiki/Observer_pattern
    public interface IEvent
    {
    }

    public struct EventPayload
    {
        public IEvent Event { get; private set; }
        public EventPayload(IEvent payload)
        {
            Event = payload;
        }
    }

    public class Unsubscriber : IDisposable
    {
        private IObserver<EventPayload> observer;
        private IList<IObserver<EventPayload>> observers;
        public Unsubscriber(IList<IObserver<EventPayload>> observers, IObserver<EventPayload> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }

    public abstract class Observable : IObservable<EventPayload>
    {
        public IList<IObserver<EventPayload>> Observers { get; set; }

        public Observable()
        {
            Observers = new List<IObserver<EventPayload>>();
        }

        public IDisposable Subscribe(IObserver<EventPayload> observer)
        {         
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
            return new Unsubscriber(Observers, observer);
        }

        public void SendMessage(EventPayload eventPayload)
        {
            foreach (var observer in Observers)
            {
                observer.OnNext(eventPayload);
            }
        }
    }
}