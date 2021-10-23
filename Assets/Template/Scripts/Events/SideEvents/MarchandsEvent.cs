using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchandsEvent : EventBehaviour
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
    public override Criticiality GetEventCriticality()
    {
        return Criticiality.Side;
    }

    public override string GetEventName()
    {
        return "Des marchands phrygiens d�barquent";
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
        GameManager.instance.AddCorruption(5);
    }

    public override void SpeechConsequence()
    {

    }

    public override void ArmyConsequence()
    {
    }
}
