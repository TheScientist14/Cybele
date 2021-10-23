using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeupleBehaviour : ActionBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction()
    {
        if (EventManager.instance.GetSelectedEvent().IsPositive())
        {
            GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier()/2);
        }
        else
        {
            GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier()*2);
        }
        EventManager.instance.GetSelectedEvent().PopulationConsequence();
        lastAction = id;
    }

    public override bool IsActive()
    {
        return true;
    }
}
