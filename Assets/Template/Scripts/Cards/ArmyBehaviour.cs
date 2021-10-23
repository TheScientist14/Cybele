using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBehaviour : ActionBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        id = "army";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void DoAction()
    {
        if (EventManager.instance.GetSelectedEvent().IsPositive())
        {
            GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier() + 1);
            EventManager.instance.GetSelectedEvent().ArmyConsequence();
        }
        //GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier() + 1);
        if (lastAction.Equals(id))
        {
            lastAction = id + 2;
        }
    }

    public override bool IsActive()
    {
        return !lastAction.Equals(id + 2);
    }
}
