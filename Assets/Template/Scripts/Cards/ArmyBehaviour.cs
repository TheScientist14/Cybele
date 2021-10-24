using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyBehaviour : ActionBehaviour
{
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
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
        PlaySound();
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
        return (!lastAction.Equals(id + "2") && GameManager.instance.IsArmyActivated());
    }
}
