using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationGUIBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        // reset Camera
    }

    public void Cancel()
    {
        CardSelection.instance.ClearSelection();
    }
}
