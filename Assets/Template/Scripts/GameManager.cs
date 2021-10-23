using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static float corruption;
    public static float timer;
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        timer = 40f;
        corruption = 10f;
        UIScript.instance.UpdateConversionBar();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        UIScript.instance.UpdateTimer();
    }
    

}