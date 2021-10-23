using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationGUIBehaviour : MonoBehaviour
{
    private CameraBehaviour cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Confirm()
    {
        CardSelection.instance.GetSelectedAction().DoAction();
        EventManager.instance.SelectEvent(null);
        CardSelection.instance.ClearSelection();
        cam.Reset();
    }

    public void Cancel()
    {
        CardSelection.instance.ClearSelection();
    }
}
