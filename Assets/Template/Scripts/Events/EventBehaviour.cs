using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EventBehaviour : MonoBehaviour
{
    private float initTime;
    private float delayStart = 3f;
    private float delayEnd = float.MaxValue;
    protected float passiveCorruptionDelta = 0.5f;
    protected float activeCorruptionDelta = 5f;
    public Dialogue dialogueArmy;
    public Dialogue dialogueSpeech;
    public Dialogue dialoguePeuple;
    public Dialogue dialogueSabotageSuccess;
    public Dialogue dialogueSabotageFail;

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

    public void ArmyConsequence()
    {
        DoEvent();
        TextManager.instance.textPanel.SetText(dialogueArmy.text);
    }

    public void SpeechConsequence()
    {
        DoEvent();
        TextManager.instance.textPanel.SetText(dialogueSpeech.text);
    }

    public void SabotageConsequence(bool success)
    {
        if (success)
        {
            TextManager.instance.textPanel.SetText(dialogueSabotageSuccess.text);
        }
        else
        {
            DoEvent();
            TextManager.instance.textPanel.SetText(dialogueSabotageFail.text);
        }
    }

    public void PopulationConsequence()
    {
        DoEvent();
        TextManager.instance.textPanel.SetText(dialoguePeuple.text);
    }

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
