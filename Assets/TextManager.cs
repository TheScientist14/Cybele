using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject phrygien;
    public GameObject romain;
    public TextMeshProUGUI textPanel;

    private Image phrygienImg;
    private Image romainImg;

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
        phrygienImg = phrygien.GetComponent<Image>();
        romainImg = romain.GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(Dialogue text)
    {
        textPanel.text = text.text;
        if (text.speaker.Equals("Tibere"))
        {
            phrygienImg.color = Color.grey;
            romainImg.color = Color.white;
        }
        else if (text.speaker.Equals("Le phrygien"))
        {
            phrygienImg.color = Color.white;
            romainImg.color = Color.grey;
        }
        else
        {
            phrygienImg.color = Color.grey;
            romainImg.color = Color.grey;
        }
    }

    public void NextText()
    {
        NextTextEvent.Invoke();
    }

}
