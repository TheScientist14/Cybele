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
        EventManager.instance.GetSelectedEvent().ArmyConsequence();
        GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier() * 2);
        if (lastAction.Equals(id))
        {
            lastAction = id + "2";
        }
        else
        {
            lastAction = id;
        }
    }

    public override bool IsActive()
    {
        Debug.Log(lastAction);
        return (!lastAction.Equals(id + "2") && GameManager.instance.IsArmyActivated());
    }
}
