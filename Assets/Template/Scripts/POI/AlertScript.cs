using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    public GameObject alert;
    public GameObject explications;
    public Button button;
    private bool firstVisit;
        
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

    public void activateAlert()
    {
        alert.SetActive(true);
        if (firstVisit)
        {
            explications.SetActive(true);
            firstVisit = false;
        }
    }

    public bool isAlertActivate()
    {
        return alert.activeInHierarchy;
    }
    
    private void desableExplications()
    {
        explications.SetActive(false);
    }
}
