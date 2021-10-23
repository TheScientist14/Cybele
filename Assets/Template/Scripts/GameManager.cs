using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public float initCorruption;

    public UnityEvent CorruptionModified;
    public UnityEvent CorruptionTempMultiplierReset;
    public GameObject deck;
    public GameObject armyCard;

    private float timer;
    // corruption related variables
    private float corruption;
    private float tempPosMultiplier; // should not be negative
    private float tempNegMultiplier; // should not be negative
    private float storyMultiplier; // never reset
    private static bool isGameFinished;
    private bool armyActivated;
    private bool posistifEvent;
    private bool nonStopConversion;

    public static GameManager instance;
    public GameObject[] poi;
    private int randomPOI;
    private int positifEventPOI;
    private static int nbEventAwake;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        deck.SetActive(false);
        isGameFinished = false;
        armyActivated = true;
        posistifEvent = true;
        nonStopConversion = false;
        timer = 0f;
        corruption = initCorruption;
        tempMultiplier = 0f;
        storyMultiplier = 0f;
        nbEventAwake = 0;
        positifEventPOI = 0;
        StartCoroutine("spawn");
        UIScript.instance.UpdateConversionBar();
        CorruptionModified.AddListener(LimitCorruption);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UIScript.instance.UpdateTimer();
        if ((int) timer == 37)
        {
            armyActivated = false;
        } else if ((int) timer == 72)
        {
            armyActivated = true;
        } else if ((int) timer == 108)
        {
            positifEventPOI = 1;
        } else if ((int) timer >= 264 && (int) timer <= 324)
        {
            storyMultiplier = 1;
        } else if ((int) timer == 324)
        {
            isGameFinished = true;
        }

    }

    void RandomAlert()
    {
        randomPOI = Random.Range(0, poi.Length - positifEventPOI);
        AlertScript alertScript = poi[randomPOI].GetComponent<AlertScript>();
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

    public float GetTime()
    {
        return timer;
    }

    IEnumerator spawn()
    {
        float spawnRate = 10f;
        while (!isGameFinished)
        {
            RandomAlert();
            yield return new WaitForSeconds(spawnRate);
            spawnRate -= 0.1f;
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
    }

    // reset multiplier
    public void AddMultipliedCorruption(float newCorruption)
    {
        float multiplier = GetTotalCorruptionMultiplier();
        if (newCorruption > 0)
        {
            corruption += newCorruption * multiplier;
        }
        else
        {
            if (multiplier != 0)
            {
                corruption += newCorruption;
            }
        }
        SetCorruptionTempMultiplier(0);
        CorruptionModified.Invoke();
        CorruptionTempMultiplierReset.Invoke();
    }

    void LimitCorruption()
    {
        if(corruption > 100)
        {
            corruption = 100;
        }
    }

    public float GetTotalCorruptionMultiplier()
    {
        return tempMultiplier + storyMultiplier;
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
        deck.SetActive(true);
        if (!armyActivated)
        {
            armyCard.SetActive(false);
        }
        else
        {
            armyCard.SetActive(true);
        }
    }

    public void DeactiveDeck()
    {
        deck.SetActive(false);
    }

    public void IncreaseNbEvent()
    {
        nbEventAwake++;
    }

    public void RemoveEventAwake()
    {
        nbEventAwake--;
    }
}
