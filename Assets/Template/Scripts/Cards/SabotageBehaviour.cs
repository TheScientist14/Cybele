using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageBehaviour : ActionBehaviour
{
    private float probabilitySuccess = 30;

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
    
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
        PlaySound();
        EventManager.instance.GetSelectedEvent().SabotageConsequence(Random.Range(0, 1) > 0.01 * probabilitySuccess);
        lastAction = id;
    }

    public override bool IsActive()
    {
        return (GameManager.instance.GetCorruption() < 50
            && (EventManager.instance.GetSelectedEvent() == null
            || !EventManager.instance.GetSelectedEvent().IsPositive()));
    }
}
