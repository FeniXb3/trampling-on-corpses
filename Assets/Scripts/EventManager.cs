using System.Collections.Generic;
using UnityEngine.Events;

internal class EventManager
{
    public static EventManager Instance { get; } = new EventManager();

    private readonly Dictionary<EventType, ParametrizedEvent> events = new Dictionary<EventType, ParametrizedEvent>();

    public void TriggerEvent(EventType targetEventType, object arg)
    {
        if(HasEvent(targetEventType))
        {
            events[targetEventType].Invoke(arg);
        }
    }

    public void AddListener(EventType targetEventType, UnityAction<object> listener)
    {
        if (!HasEvent(targetEventType))
        {
            events[targetEventType] = new ParametrizedEvent();
        }
        events[targetEventType].AddListener(listener);
    }

    public void RemoveListener(EventType targetEventType, UnityAction<object> listener)
    {
        if (HasEvent(targetEventType))
        {
            events[targetEventType].RemoveListener(listener);
        }
    }

    private bool HasEvent(EventType targetEventType)
    {
        return events.ContainsKey(targetEventType) && events[targetEventType] != null;
    }

    private class ParametrizedEvent: UnityEvent<object>{}
}