using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public EventList storyEventList;
    public EventList sideEventList;

    private EventBehaviour selectedEvent;
    public UnityEvent EventHasBeenSelected;

    //private IDictionary<string, EventBehaviour> events;
    //private EventBehaviour[] events;

    public static EventManager instance;

    void Awake()
    {
        EventHasBeenSelected = new UnityEvent();
    }
    
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

    public EventBehaviour GetSelectedEvent()
    {
        return selectedEvent;
    }

    public void SelectEvent(EventBehaviour evnt)
    {
        selectedEvent = evnt;
        EventHasBeenSelected.Invoke();
    }

    /*
     * Event selection listener handling
     */
    public void AddEventSelectionListener(UnityAction listener)
    {
        EventHasBeenSelected.AddListener(listener);
    }

    public void RemoveEventSelectionListener(UnityAction listener)
    {
        EventHasBeenSelected.RemoveListener(listener);
    }
}
