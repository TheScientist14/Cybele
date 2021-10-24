using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictionEvent : EventBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        activeCorruptionDelta = -5f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }


    public override Criticiality GetEventCriticality()
    {
        return Criticiality.Side;
    }

    public override string GetEventName()
    {
        return "Des restrictions sont mises en place";
    }

    public void SabotageConsequence()
    {
        throw new System.Exception("Can�t sabotage your own rules !");
    }

}
