using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBehaviour : ActionBehaviour
{
    private bool hasBeenUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.CorruptionTempMultiplierReset.AddListener(Reset);
        id = "speech";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void DoAction()
    {
        EventManager.instance.GetSelectedEvent().SpeechConsequence();
        GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier() / 2);
        lastAction = id;
        hasBeenUsed = true;
    }

    public override bool IsActive()
    {
        return !hasBeenUsed;
    }

    public void Reset()
    {
        hasBeenUsed = false;
    }
}
