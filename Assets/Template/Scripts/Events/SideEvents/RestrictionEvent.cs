using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictionEvent : EventBehaviour
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

    }

    public override Criticiality GetEventCriticality()
    {
        return Criticiality.Side;
    }

    public override string GetEventName()
    {
        return "Des restrictions sont mises en place";
    }

    public override bool IsPositive()
    {
        return true;
    }

    public override void PopulationConsequence()
    {

    }

    public override void SabotageConsequence()
    {
    }

    public override void SpeechConsequence()
    {

    }
}
