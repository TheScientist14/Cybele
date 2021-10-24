using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutoScript : MonoBehaviour
{
    public Dialogue intro;
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
        GameManager.instance.SetIsRunning(false);
        army.GetComponent<CardBehaviour>().Hide();
        sabotage.GetComponent<CardBehaviour>().Hide();
        speech.GetComponent<CardBehaviour>().Hide();
        peuple.GetComponent<CardBehaviour>().Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (listenProcession)
        {
            if (!notif.isAlertActivate())
            {
                TextManager.instance.gameObject.SetActive(true);
                TextManager.instance.SetText(intro);
                army.GetComponent<CardBehaviour>().Hide();
                sabotage.GetComponent<CardBehaviour>().Hide();
                speech.GetComponent<CardBehaviour>().Hide();
                peuple.GetComponent<CardBehaviour>().Hide();
                listenProcession = false;
            }
        }
    }

    void Next()
    {
        Debug.Log("Next");
        switch (iText)
        {
            case 3:
                notif.activateAlert();
                listenProcession = true;
                break;
            case 4:
                if (listenProcession)
                {
                    TextManager.instance.gameObject.SetActive(false);
                }
                break;
            case 7:
                army.GetComponent<CardBehaviour>().Show();
                army.GetComponent<Button>().enabled = false;
                break;
            case 8:
                sabotage.GetComponent<CardBehaviour>().Show();
                army.GetComponent<Button>().enabled = false;
                break;
            case 9:
                speech.GetComponent<CardBehaviour>().Show();
                army.GetComponent<Button>().enabled = false;
                break;
            case 10:
                peuple.GetComponent<CardBehaviour>().Show();
                army.GetComponent<Button>().enabled = false;
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
            TextManager.instance.SetText(intro);
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
