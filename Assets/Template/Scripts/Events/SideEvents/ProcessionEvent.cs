using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessionEvent : EventBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void ArmyConsequence()
    {
        DoEvent();
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

    public override string GetEventName()
    {
        return "Procession des adeptes de Cyb�le en pleine rue";
    }

    public override Criticiality GetEventCriticality()
    {
        return Criticiality.Side;
    }

    // Update is called once per frame
    new void Update()
    {
        
        base.Update();
    }
}
