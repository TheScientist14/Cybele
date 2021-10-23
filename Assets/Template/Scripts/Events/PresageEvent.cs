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
    void Update()
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
        return "Sombre présage";
    }

    public override bool IsPositive()
    {
        return false;
    }

    public override void PopulationConsequence()
    {
        
    }

    public override void SabotageConsequence()
    {
        GameManager.instance.AddCorruption(5f);
    }

    public override void SpeechConsequence()
    {
        
    }

}
