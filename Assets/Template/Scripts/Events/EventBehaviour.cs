using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBehaviour : MonoBehaviour
{
    private float initTime;
    private float delayStart = 3f;
    private float delayEnd = float.MaxValue;
    protected float passiveCorruptionDelta = 0.5f;
    protected float activeCorruptionDelta = 5f;

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
    public void Update()
    {
        if (GameManager.instance.GetTime() > initTime + delayStart)
        {
            if (GameManager.instance.GetTime() < initTime + delayEnd)
            {
                GameManager.instance.AddPassiveCorruption(passiveCorruptionDelta*Time.deltaTime);
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

    public bool IsPositive()
    {
        return (activeCorruptionDelta < 0);
    }

    public void DoEvent()
    {
        GameManager.instance.AddMultipliedCorruption(activeCorruptionDelta);
    }
}
