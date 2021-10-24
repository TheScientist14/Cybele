using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    public GameObject alert;
        
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateAlert()
    {
        alert.SetActive(true);
        
    }

    public bool isAlertActivate()
    {
        return alert.activeInHierarchy;
    }
    
}
