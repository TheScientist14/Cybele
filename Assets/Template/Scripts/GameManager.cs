using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public float initCorruption;

    public UnityEvent CorruptionModified;

    private float timer;
    // corruption related variables
    private float corruption;
    private float tempMultiplier; // should not be negative
    private float storyMultiplier; // never reset
    private bool isGameFinished;

    public static GameManager instance;
    public GameObject[] poi;
    private int randomPOI;
    
    // Start is called before the first frame update
    void Start()
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

        isGameFinished = false;
        timer = 40f;
        corruption = initCorruption;
        tempMultiplier = 0f;
        storyMultiplier = 0f;
        StartCoroutine("spawn");
        UIScript.instance.UpdateConversionBar();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        UIScript.instance.UpdateTimer();
        if ((int) timer == 0)
        {
            isGameFinished = true;
        }
    }

    void RandomAlert()
    {
        randomPOI = Random.Range(0, 5);
        if (!poi[randomPOI].GetComponent<AlertScript>().isAlertActivate())
        {
            poi[randomPOI].GetComponent<AlertScript>().activateAlert();
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
        float spawnRate = 0.5f;
        while (!isGameFinished)
        {
            RandomAlert();
            yield return new WaitForSeconds(1 / spawnRate);
            spawnRate -= 0.02f;
        }
    }

    /*
     * Corruption handling
     */
    public float GetCorruption()
    {
        return corruption;
    }

    // reset multiplier if not the same action
    public void AddCorruption(float newCorruption)
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
                corruption += newCorruption / multiplier;
            }
        }
        CorruptionModified.Invoke();
    }

    public float GetTotalCorruptionMultiplier()
    {
        return 1 + tempMultiplier + storyMultiplier;
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
}