using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent GameStart;
    public UnityEvent CorruptionModified;
    public EventList storyEventList;
    public EventList sideEventList;
    public float initCorruption;

    private IDictionary<string, UnityEvent> events;

    private float corruption;
    private float multiplier; // should not be negative

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
        corruption = initCorruption;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Corruption handling
     */
    public float GetCorruption()
    {
        return corruption;
    }

    public float GetCorruptionMultiplier()
    {
        return multiplier;
    }

    // reset multiplier if not the same event
    public void AddCorruption(float newCorruption)
    {
        if(newCorruption > 0)
        {
            corruption += newCorruption*multiplier;
        }
        else
        {
            if(multiplier != 0)
            {
                corruption += newCorruption / multiplier;
            }
        }
        CorruptionModified.Invoke();
    }

    public void SetCorruptionMultiplier(float newMultiplier)
    {
        multiplier = newMultiplier;
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
