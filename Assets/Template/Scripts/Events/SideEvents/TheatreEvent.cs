using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheatreEvent : EventBehaviour
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
        GameManager.instance.AddCorruption(2f);
    }

    public override Criticiality GetEventCriticality()
    {
        return Criticiality.Side;
    }

    public override string GetEventName()
    {
        return "Pi�ces de th��tre des M�gal�sies";
    }

    public override bool IsPositive()
    {
        return false;
    }

    public override void PopulationConsequence()
    {
        GameManager.instance.AddCorruption(10);
    }

    public override void SabotageConsequence()
    {
        GameManager.instance.AddCorruption(5);
    }

    public override void SpeechConsequence()
    {

    }
}
