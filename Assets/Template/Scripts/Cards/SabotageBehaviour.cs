using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageBehaviour : ActionBehaviour
{
    private float probability = 50;

    // Start is called before the first frame update
    void Start()
    {
        id = "sabotage";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction()
    {
        if(Random.Range(0, 1) > 0.01 * probability)
        {
            // sabotage has failed
            EventManager.instance.GetSelectedEvent().SabotageConsequence();
            lastAction = id;
        }
        else
        {
            // sabotage has been successful
        }
    }

    public override bool IsActive()
    {
        return true;
    }
}
