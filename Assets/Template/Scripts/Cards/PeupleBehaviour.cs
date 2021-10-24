using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeupleBehaviour : ActionBehaviour
{
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        id = "peuple";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction()
    {
        PlaySound();
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
