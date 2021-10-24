using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeechBehaviour : ActionBehaviour
{
    private bool hasBeenUsed = false;
 
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
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
        PlaySound();
        EventManager.instance.GetSelectedEvent().SpeechConsequence();
        GameManager.instance.SetCorruptionTempMultiplier(GameManager.instance.GetCorruptionTempMultiplier() / 1.5f);
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
