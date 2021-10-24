using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject phrygien;
    public GameObject romain;
    public TextMeshProUGUI textPanel;

    public UnityEvent NextTextEvent;

    public static TextManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        NextTextEvent = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(Text text)
    {
        textPanel.text = text.text;
    }

    public void NextText()
    {
        NextTextEvent.Invoke();
    }
}
