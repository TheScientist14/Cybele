using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public static UIScript instance;
    public TextMeshProUGUI conversionBarText;
    public TextMeshProUGUI TimerText;
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        GameManager.instance.CorruptionModified.AddListener(UpdateConversionBar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateConversionBar()
    {
        slider.value = (int) GameManager.instance.GetCorruption();
        conversionBarText.SetText(GameManager.instance.GetCorruption() + "%");
    }

    public void UpdateTimer()
    {
        TimerText.SetText("Timer :" + (int) GameManager.instance.GetTime());
    }
}
