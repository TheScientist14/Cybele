using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownScript : MonoBehaviour
{
    private new Camera camera;
    public GameObject alert;
    private EventBehaviour evnt;

    void Awake()
    {
        camera = Camera.main;
        evnt = alert.GetComponent<EventBehaviour>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        alert.SetActive(false);
        GameManager.instance.RemoveEventAwake();
        camera.transform.position = gameObject.transform.position + new Vector3(0,0,-2.5f);
        camera.orthographicSize = 0.75f;
        GameManager.instance.ActiveDeck();
        EventManager.instance.SelectEvent(evnt);
    }
}
