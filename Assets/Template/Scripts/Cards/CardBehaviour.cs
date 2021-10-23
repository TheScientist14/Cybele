using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionBehaviour))]
public class CardBehaviour : MonoBehaviour
{
    private ActionBehaviour cardAction;
    private Vector3 standardScale;

    void Awake()
    {
        cardAction = gameObject.GetComponent<ActionBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CardSelection.instance.AddListener(HighlightIfSelected);
        standardScale = transform.localScale;
    }

    void Update()
    {
    }

    public void Click()
    {
        CardSelection.instance.SelectAction(cardAction);
    }

    public void HighlightIfSelected()
    {
        if(CardSelection.instance.GetSelectedAction() == cardAction)
        {
            transform.localScale = standardScale*1.5f;
        }
        else
        {
            transform.localScale = standardScale;
        }
    }
}
