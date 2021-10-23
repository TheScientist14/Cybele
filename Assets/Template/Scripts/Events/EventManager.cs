using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public EventList storyEventList;
    public EventList sideEventList;

    private IDictionary<string, UnityEvent> events;

    void Awake()
    {
        // init events
        events = new Dictionary<string, UnityEvent>();
        foreach (string name in storyEventList.eventsName)
        {
            events.Add(name.ToLower(), new UnityEvent());
        }
        foreach (string name in sideEventList.eventsName)
        {
            events.Add(name.ToLower(), new UnityEvent());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Events listeners handling
     */
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
    }
}
