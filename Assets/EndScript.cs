using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public Dialogue[] ends;

    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.GetCorruption() <= 10)
        {
            text.SetText(ends[0].text);
        }
        else if(GameManager.instance.GetCorruption() >= 80)
        {
            text.SetText(ends[2].text);
        }
        else
        {
            text.SetText(ends[1].text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
