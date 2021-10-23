using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownScript : MonoBehaviour
{
    private new Camera camera;
    public GameObject alert;

    void Awake()
    {
        camera = Camera.main;
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
        camera.transform.position = gameObject.transform.position + new Vector3(0,0,-2.5f);
        camera.orthographicSize = 0.75f;
        GameManager.instance.ActiveDeck();
    }
}
