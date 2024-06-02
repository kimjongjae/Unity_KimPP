using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public enum GameEventType
{
   
}

public class GameEventObserver : MonoBehaviour
{
    private static readonly IDictionary<GameEventType, UnityEvent<object>>
        Events = new Dictionary<GameEventType, UnityEvent<object>>();

    public static void Subscribe(GameEventType eventType, UnityAction<object> listener)
    {
        UnityEvent<object> thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<object>();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void UnSubscribe(GameEventType eventType, UnityAction<object> listener)
    {
        UnityEvent<object> thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(GameEventType eventType, object Data)
    {
        UnityEvent<object> thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke(Data);
        }
    }
}
