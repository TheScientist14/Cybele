using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardSelection : MonoBehaviour
{
    private ActionBehaviour selectedCard;

    private UnityEvent SelectionHasChanged;

    public static CardSelection instance;

    void Awake()
    {
        // Singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SelectionHasChanged = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearSelection()
    {
        selectedCard = null;
        SelectionHasChanged.Invoke();
    }

    public void SelectAction(ActionBehaviour card)
    {
        selectedCard = card;
        SelectionHasChanged.Invoke();
    }

    public ActionBehaviour GetSelectedAction()
    {
        return selectedCard;
    }

    public void AddListener(UnityAction listener)
    {
        SelectionHasChanged.AddListener(listener);
    }

    public void RemoveListener(UnityAction listener)
    {
        SelectionHasChanged.RemoveListener(listener);
    }
}
