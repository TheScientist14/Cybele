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
    public UnityEvent EventSelectionCleared;

    private Camera cam;
    private CameraBehaviour camBehaviour;

    public static EventManager instance;

    void Awake()
    {
        EventHasBeenSelected = new UnityEvent();
        EventSelectionCleared = new UnityEvent();
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camBehaviour = cam.GetComponent<CameraBehaviour>();
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

    public void ClearSelection()
    {
        selectedEvent = null;
        CardSelection.instance.ClearSelection();
        EventSelectionCleared.Invoke();
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
