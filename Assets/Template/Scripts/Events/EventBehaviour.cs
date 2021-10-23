using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBehaviour : MonoBehaviour
{
    private float initTime;
    private float delayStart = 5;
    private float delayEnd;
    protected float corruptionDelta = 5;

    public enum Criticiality{
        Side,
        Main
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        initTime = GameManager.instance.GetTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetTime() > initTime + delayStart)
        {
            if (GameManager.instance.GetTime() < initTime + delayEnd)
            {
                GameManager.instance.AddCorruption(corruptionDelta*Time.deltaTime);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public abstract void ArmyConsequence();
    public abstract void SpeechConsequence();
    public abstract void SabotageConsequence();
    public abstract void PopulationConsequence();

    public abstract string GetEventName();

    public abstract Criticiality GetEventCriticality();

    public abstract bool IsPositive();
}
