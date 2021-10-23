using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector3 initPos;
    private float initOrthographicSize;
    private Camera cam;

    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        initOrthographicSize = cam.orthographicSize;
        EventManager.instance.EventSelectionCleared.AddListener(Reset);
    }

    public void Reset()
    {
        transform.position = initPos;
        cam.orthographicSize = initOrthographicSize;
    }
}
