using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    private Camera cam;
    private bool isDragged;
    //private Vector2 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        isDragged = false;
    }

    void OnMouseDown()
    {
        //isDragged = true;
        //oldPos = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        //transform.position = Input.mousePosition;
    }
}
