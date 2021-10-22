using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownScript : MonoBehaviour
{
    private new Camera camera;

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
        camera.transform.position = gameObject.transform.position + new Vector3(0,0,-2.5f);
        camera.orthographicSize = 1f;
    }
}
