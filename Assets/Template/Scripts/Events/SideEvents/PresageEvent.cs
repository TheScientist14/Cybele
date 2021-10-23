using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresageEvent : EventBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        
        base.Update();
    }

    public override void ArmyConsequence()
    {
        DoEvent();
    }

    public override Criticiality GetEventCriticality()
    {
        return Criticiality.Side;
    }

    public override string GetEventName()
    {
        return "Sombre présage";
    }

    public override void PopulationConsequence()
    {
        DoEvent();
    }

    public override void SabotageConsequence()
    {
        DoEvent();
    }

    public override void SpeechConsequence()
    {
        DoEvent();
    }

}
