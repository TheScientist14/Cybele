using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouseDownScript : MonoBehaviour
{
    private new Camera camera;
    public GameObject alert;
    private EventBehaviour evnt;
    public Button button;
    private bool firstVisit;
    public GameObject explications;
    public AudioClip sound;

    void Awake()
    {
        camera = Camera.main;
        evnt = alert.GetComponent<EventBehaviour>();
    }
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(desableExplications);
        firstVisit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
        if (evnt.isActiveAndEnabled)
        {
            alert.SetActive(false);
            if (firstVisit)
            {
                explications.SetActive(true);
                try
                {
                    GameManager.instance.PauseGame();
                }
                catch {};
                firstVisit = false;
            }
            try
            {
                GameManager.instance.RemoveEventAwake();
            }
            catch { };
        camera.transform.position = gameObject.transform.position + new Vector3(0,0,-2.5f);
            camera.orthographicSize = 0.75f;
            try
            {
                GameManager.instance.ActiveDeck();
            }
            catch { };
            EventManager.instance.SelectEvent(evnt);
        }
    }
    
    public void desableExplications()
    {
        explications.SetActive(false);
        try
        {
            GameManager.instance.ResumeGame();
        }
        catch { };
    }
}
