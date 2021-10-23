using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMapBehaviour : MonoBehaviour
{

    private new Camera camera;
    private Vector3 cameraPositionDefault;

    void Awake()
    {
        camera = Camera.main;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        cameraPositionDefault = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(","))
        {
            camera.transform.position = cameraPositionDefault;
            camera.orthographicSize = 5f;
            GameManager.instance.DeactiveDeck();
        }
    }
}
