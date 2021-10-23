using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionBehaviour))]
[RequireComponent(typeof(Collider))]
public class CardBehaviour : MonoBehaviour
{
    private ActionBehaviour cardAction;

    void Awake()
    {
        cardAction = gameObject.GetComponent<ActionBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CardSelection.instance.AddListener(MoveIfSelected);
    }

    void OnMouseDown()
    {
        CardSelection.instance.SelectAction(cardAction);
    }

    public void MoveIfSelected()
    {
        if(CardSelection.instance.GetSelectedAction() == this)
        {
            transform.position += 10*transform.up;
        }
        else
        {
            // ?
        }
    }
}
