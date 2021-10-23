using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public EventList storyEventList;
    public EventList sideEventList;

    private EventBehaviour selectedEvent;

    //private IDictionary<string, EventBehaviour> events;
    //private EventBehaviour[] events;

    public static EventManager instance;

    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // init events
        /*events = new Dictionary<string, UnityEvent>();
        foreach (EventBehaviour evnt in storyEventList.events)
        {
            events.Add(evnt.GetEventName().ToLower(), new UnityEvent());
        }
        foreach (EventBehaviour evnt in sideEventList.events)
        {
            events.Add(evnt.GetEventName().ToLower(), new UnityEvent());
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
    /*
     * Events listeners handling
     * /
    public void AddListener(string eventName, UnityAction listener)
    {
        events[eventName].AddListener(listener);
    }

    public void RemoveListener(string eventName, UnityAction listener)
    {
        events[eventName].RemoveListener(listener);
    }

    public void Invoke(string eventName)
    {
        events[eventName].Invoke();
    }*/
}
