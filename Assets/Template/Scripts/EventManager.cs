using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent GameStart;
    public UnityEvent CorruptionModified;
    public Story story;

    private IDictionary<string, UnityEvent> storyEvents;

    private float corruption;
    private float multiplier; // should not be negative

    void Awake()
    {
        storyEvents = new Dictionary<string, UnityEvent>();
        foreach (string name in story.eventsName)
        {
            storyEvents.Add(name.ToLower(), new UnityEvent());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        corruption = story.initCorruption;
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
        storyEvents[eventName].AddListener(listener);
    }

    public void RemoveListener(string eventName, UnityAction listener)
    {
        storyEvents[eventName].RemoveListener(listener);
    }

    public void Invoke(string eventName)
    {
        storyEvents[eventName].Invoke();
    }
}
