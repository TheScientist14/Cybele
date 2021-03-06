using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBehaviour : MonoBehaviour
{
    protected static string lastAction = "";
    protected string id;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // should implement the behaviour of the card when it is placed on a point of interest
    public abstract void DoAction();

    public abstract bool IsActive();

}
