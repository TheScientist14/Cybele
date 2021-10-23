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
            GameManager.instance.SetCorruptionTempMultiplier(1 / (2 * GameManager.instance.GetCorruptionTempMultiplier()));
        }
        else
        {
            GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier());
        }
        EventManager.instance.GetSelectedEvent().PopulationConsequence();
        lastAction = id;
    }

    public override bool IsActive()
    {
        return true;
    }
}
