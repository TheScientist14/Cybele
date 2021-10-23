using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBehaviour : ActionBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastAction == "army")
        {
            gameObject.SetActive(false);
        }
    }

    public override void DoAction()
    {
        GameManager.instance.SetCorruptionTempMultiplier(1);
        lastAction = "army";
    }
}
