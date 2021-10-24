using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutoScript : MonoBehaviour
{
    public Text intro;
    public GameObject processionObject;
    public GameObject army;
    public GameObject speech;
    public GameObject sabotage;
    public GameObject peuple;

    private EventBehaviour procession;
    private AlertScript notif;

    private int iText;
    private bool listenProcession = false;

    void Awake()
    {
        procession = processionObject.GetComponent<EventBehaviour>();
        notif = processionObject.GetComponent<AlertScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        TextManager.instance.NextTextEvent.AddListener(Next);
        iText = 1;
        TextManager.instance.SetText(intro);
    }

    // Update is called once per frame
    void Update()
    {
        if (listenProcession)
        {
            if (notif.isAlertActivate())
            {
                TextManager.instance.gameObject.SetActive(true);
                TextManager.instance.SetText(intro);
                listenProcession = false;
            }
        }
    }

    void runTuto()
    {
        
    }

    void Next()
    {
        switch (iText)
        {
            case 3:
                notif.activateAlert();
                // TODO block click
                break;
            case 4:
                TextManager.instance.gameObject.SetActive(false);
                listenProcession = true;
                // TODO allow click
                break;
            case 5:
                // TODO block click
                break;
            case 7:
                army.GetComponent<CardBehaviour>().Show();
                break;
            case 8:
                sabotage.GetComponent<CardBehaviour>().Show();
                break;
            case 9:
                speech.GetComponent<CardBehaviour>().Show();
                break;
            case 10:
                peuple.GetComponent<CardBehaviour>().Show();
                break;
            case 11:
                GameManager.instance.AddPassiveCorruption(1);
                break;
            case 12:
                TextManager.instance.gameObject.SetActive(false);
                // TODO allow click
                EventManager.instance.EventSelectionCleared.AddListener(Next);
                break;
        }
        if(intro.nextText != null)
        {
            intro = intro.nextText;
            iText++;
        }
        else
        {
            EventManager.instance.EventSelectionCleared.RemoveListener(Next);
            GameManager.instance.EndTuto();
            SceneManager.LoadScene(2);
        }
    }
}
