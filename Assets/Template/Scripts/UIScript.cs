using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public static UIScript instance;
    public TextMeshProUGUI conversionBarText;
    public TextMeshProUGUI MonthText;
    public TextMeshProUGUI YearText;
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
        slider.value = GameManager.instance.GetCorruption();    
        if (GameManager.instance.GetCorruption() == 0)
        {
            conversionBarText.SetText(GameManager.instance.GetCorruption() + "%");
        }
        else
        {
            conversionBarText.SetText(GameManager.instance.GetCorruption().ToString("0.00") + "%");
        }
    }

    public void UpdateTimer()
    {
        int year = ((int) GameManager.instance.GetTime() / 12) + 14;
        int month = (int) GameManager.instance.GetTime() % 12 + 1;
        DateTime date = new DateTime(year, month, 1);
        MonthText.SetText( date.ToString("MMM") + "");
        YearText.SetText(year + "");
    }
}
