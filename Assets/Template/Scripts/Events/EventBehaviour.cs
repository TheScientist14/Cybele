using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBehaviour : MonoBehaviour
{
    public enum Criticiality{
        Side,
        Main
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void ArmyConsequence();
    public abstract void SpeechConsequence();
    public abstract void SabotageConsequence();
    public abstract void PopulationConsequence();

    public abstract string GetEventName();

    public abstract Criticiality GetEventCriticality();
}
