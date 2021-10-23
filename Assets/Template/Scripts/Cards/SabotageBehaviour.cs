using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageBehaviour : ActionBehaviour
{
    private float probabilitySuccess = 30;

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
        if(Random.Range(0, 1) > 0.01 * probabilitySuccess)
        {
            // sabotage has failed
            EventManager.instance.GetSelectedEvent().SabotageConsequence();
        }
        else
        {
            // sabotage has been successful
        }
        lastAction = id;
    }

    public override bool IsActive()
    {
        return (GameManager.instance.GetCorruption() < 50
            && !EventManager.instance.GetSelectedEvent().IsPositive());
    }
}
