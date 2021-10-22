using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event list", menuName = "Event list")]
public class EventList : ScriptableObject
{
    // array containing name of every event
    public string[] eventsName;
}
