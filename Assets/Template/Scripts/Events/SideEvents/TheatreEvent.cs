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
    new void Update()
    {
        
        base.Update();
    }

    public void ArmyConsequence()
    {
        float oldMultiplier = GameManager.instance.GetCorruptionTempMultiplier();
        GameManager.instance.SetCorruptionTempMultiplier(-0.5f);
        DoEvent();
        GameManager.instance.SetCorruptionTempMultiplier(oldMultiplier);
    }

    public override Criticiality GetEventCriticality()
    {
        return Criticiality.Side;
    }

    public override string GetEventName()
    {
        return "Pi�ces de th��tre des M�gal�sies";
    }
}
