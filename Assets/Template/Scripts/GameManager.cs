using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float initCorruption;

    public GameObject PauseScreen;
    public Button ResumeButton;
    public Button ExitButton;
    public UnityEvent CorruptionModified;
    public UnityEvent CorruptionTempMultiplierReset;
    public UnityEvent UpdateDeckEvent;
    public GameObject[] cards;
    public GameObject dialogue;
    public Dialogue text;
    private bool corruptionSup;

    private float timer;
    // corruption related variables
    private float corruption;
    private float tempMultiplier; // should not be negative
    private float storyMultiplier; // never reset
    private bool isGameFinished;
    private bool isRunning;
    private bool isTuto;
    private bool armyActivated;

    public GameObject[] poi;
    private int randomPOI;
    private int positifEventPOI;
    private List<KeyValuePair<ActionBehaviour, CardBehaviour>> actionsBehaviour;

    public static GameManager instance;
    private int nbEventAwake;
    private AlertScript alertScript;
    private bool isDeckActive = false;

    void Awake()
    {
        // Singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        CorruptionModified = new UnityEvent();
        CorruptionTempMultiplierReset = new UnityEvent();
        UpdateDeckEvent = new UnityEvent();
        actionsBehaviour = new List<KeyValuePair<ActionBehaviour, CardBehaviour>>();
        foreach (GameObject card in cards)
        {
            ActionBehaviour actionBehaviour = card.GetComponent<ActionBehaviour>();
            CardBehaviour cardBehaviour = card.GetComponent<CardBehaviour>();
            if(actionBehaviour != null && cardBehaviour != null)
            {
                actionsBehaviour.Add(new KeyValuePair<ActionBehaviour, CardBehaviour>(actionBehaviour, cardBehaviour));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PauseScreen.SetActive(false);
        isGameFinished = false;
        isRunning = true;
        isTuto = false;
        armyActivated = true;
        corruptionSup = false;
        timer = 0f;
        corruption = initCorruption;
        tempMultiplier = 1f;
        storyMultiplier = 1f;
        nbEventAwake = 0;
        positifEventPOI = 0;
        DeactiveDeck();
        StartCoroutine("spawn");
        UIScript.instance.UpdateConversionBar();
        CorruptionModified.AddListener(LimitCorruption);
        UpdateDeckEvent.AddListener(UpdateDeck);
        EventManager.instance.EventSelectionCleared.AddListener(DeactiveDeck);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            PauseGameScreen();
        }
        if (IsRunning())
        {
            timer += Time.deltaTime;
            UIScript.instance.UpdateTimer();
            if ((int) timer == 37)
            {
                
                if (armyActivated)
                {
                    armyActivated = false;
                    UpdateDeckEvent.Invoke();
                }
            } else if ((int) timer == 72)
            {
                if (!armyActivated)
                {
                    armyActivated = true;
                    UpdateDeckEvent.Invoke();
                }
            } else if ((int) timer == 108)
            {
                positifEventPOI = 1;
            } else if ((int) timer >= 264 && (int) timer <= 324)
            {
                if(storyMultiplier == 1)
                {
                    storyMultiplier = 2;
                    UpdateDeckEvent.Invoke();
                }
            } else if ((int) timer == 324)
            {
                isGameFinished = true;
            }
        }
    }

    public bool IsRunning()
    {
        return !isGameFinished && isRunning && !isTuto;
    }

    void RandomAlert()
    {
        if (nbEventAwake < poi.Length)
        {
            randomPOI = Random.Range(0, poi.Length - positifEventPOI);
            alertScript = poi[randomPOI].GetComponent<AlertScript>();
            if (!alertScript.isAlertActivate())
            {
                alertScript.activateAlert();
                IncreaseNbEvent();
            }
            else
            {
                RandomAlert();
            }
        }
    }

    public void SpawnProcession()
    {
        alertScript = poi[3].GetComponent<AlertScript>();
        alertScript.activateAlert();
        IncreaseNbEvent();
    }

    public float GetTime()
    {
        return timer;
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(3);
        float spawnRate = 10f;
        while (true)
        {
            if (IsRunning())
            {
                RandomAlert();
                yield return new WaitForSeconds(spawnRate);
                spawnRate -= 0.1f;
            }
        }
    }

    /*
     * Corruption handling
     */
    public float GetCorruption()
    {
        return corruption;
    }

    public void AddPassiveCorruption(float corruptionDelta)
    {
        corruption += corruptionDelta;
        CorruptionModified.Invoke();
        if (corruption >= 50 && !corruptionSup)
        {
            corruptionSup = true;
            dialogue.SetActive(true);
            TextManager.instance.textPanel.SetText(text.text);
        }
    }

    // reset multiplier
    public void AddMultipliedCorruption(float corruptionAdded)
    {
        float corruptionDelta = GetTotalCorruptionMultiplier() * corruptionAdded;
        if (corruptionDelta > 0)
        {
            corruption += corruptionDelta;
            SetCorruptionTempMultiplier(1);
            CorruptionTempMultiplierReset.Invoke();
            if (corruption >= 50 && !corruptionSup)
            {
                corruptionSup = true;
                dialogue.SetActive(true);
                TextManager.instance.textPanel.SetText(text.text);
            }
        }
        else
        {
            corruption += corruptionAdded;
        }
        CorruptionModified.Invoke();
    }

    void LimitCorruption()
    {
        if(corruption > 100)
        {
            corruption = 100;
        }
        if(corruption < 0)
        {
            corruption = 0;
        }
    }

    public float GetTotalCorruptionMultiplier()
    {
        return tempMultiplier * storyMultiplier;
    }

    public float GetCorruptionTempMultiplier()
    {
        return tempMultiplier;
    }

    public void SetCorruptionTempMultiplier(float newMultiplier)
    {
        tempMultiplier = newMultiplier;
    }

    public float GetCorruptionStoryMultiplier()
    {
        return storyMultiplier;
    }

    public void SetCorruptionStoryMultplier(float newMultiplier)
    {
        storyMultiplier = newMultiplier;
    }

    public void ActiveDeck()
    {
        isDeckActive = true;
        foreach (KeyValuePair<ActionBehaviour, CardBehaviour> card in actionsBehaviour)
        {
            if (card.Key.IsActive())
            {
                card.Value.Show();
            }
            else
            {
                card.Value.Hide();
            }
        }
    }

    public void DeactiveDeck()
    {
        isDeckActive = false;
        foreach (KeyValuePair<ActionBehaviour, CardBehaviour> card in actionsBehaviour)
        {
            card.Value.Hide();
        }
    }

    public void UpdateDeck()
    {
        if (isDeckActive)
        {
            ActiveDeck();
        }
    }

    public void IncreaseNbEvent()
    {
        nbEventAwake++;
    }

    public void RemoveEventAwake()
    {
        nbEventAwake--;
    }

    public bool IsArmyActivated()
    {
        return armyActivated;
    }

    public void EndTuto()
    {
        isTuto = false;
    }

    public void PauseGameScreen()
    {
        PauseScreen.SetActive(true);
        PauseGame();
    }
    
    public void PauseGame()
    {
        isRunning = false;
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        isRunning = true;
    }

    public void SetIsRunning(bool b)
    {
        isRunning = b;
    }

    public void CloseDialogue()
    {
        dialogue.SetActive(false);
    }
}
