using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static float corruption;
    public static float timer;
    public static GameManager instance;
    public GameObject[] poi;
    private int randomPOI;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        randomPOI = Random.Range(0, 5);
        
        Debug.Log("random : " + randomPOI);
        
        timer = 40f;
        corruption = 10f;
        UIScript.instance.UpdateConversionBar();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        UIScript.instance.UpdateTimer();
        if ((int) timer == 35)
        {
            RandomAlert();
        }
    }

    void RandomAlert()
    {
        Debug.Log("RandomAlert methode");
        poi[randomPOI].GetComponent<AlertScript>().activateAlert();
    }

}