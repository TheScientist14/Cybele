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
    public GameObject PanelDialogue;
    public GameObject Tybere;
    public GameObject Phrygien;
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
        PanelDialogue.SetActive(true);
        ChangeText(dialogueArmy.text);
    }

    public void SpeechConsequence()
    {
        DoEvent();
        PanelDialogue.SetActive(true);
        ChangeText(dialogueSpeech.text);
    }

    public void SabotageConsequence(bool success)
    {
        PanelDialogue.SetActive(true);
        if (success)
        {
            ChangeText(dialogueSabotageSuccess.text);
        }
        else
        {
            DoEvent();
            ChangeText(dialogueSabotageFail.text);
        }
    }

    public void PopulationConsequence()
    {
        DoEvent();
        ChangeText(dialoguePeuple.text);
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

    public void ChangeText(string dialogue)
    {
        PanelDialogue.SetActive(true);
        TextManager.instance.textPanel.SetText(dialogue);
    }
}
